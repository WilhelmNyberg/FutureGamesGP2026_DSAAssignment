using System;
using System.Collections.Generic;
using UnityEngine;

namespace StoringData {
    public class BinaryTreeNode<T> {
        List<T> nodeData;
        public T[] Value { get { return nodeData.ToArray(); } }
        public BinaryTreeNode<T> left = null;
        public BinaryTreeNode<T> right = null;
        public BinaryTreeNode(T data) {
            nodeData = new();
            nodeData.Add(data);
        }
    }
    public class BinaryTree {

        BinaryTreeNode<Employees.Employee> treeRoot = null;
        
        int treeHeight = 0; 

        public BinaryTree(Employees.Employee root){
            treeRoot = new BinaryTreeNode<Employees.Employee>(root);
        }
        public BinaryTree(Employees.Employee[] initialData) {
            int median = initialData.Length / 2;
            treeRoot = new BinaryTreeNode<Employees.Employee>(initialData[median]);
            for(int i = 0; i < initialData.Length; i++) {
                if(i == median) continue;
                Insert(initialData[i]);
            }
        }
        public void Insert(Employees.Employee data) {
            BinaryTreeNode<Employees.Employee> newNode = new BinaryTreeNode<Employees.Employee>(data);
            InsertInParent(treeRoot, newNode);
        }

        void InsertInParent(BinaryTreeNode<Employees.Employee> newNode, BinaryTreeNode<Employees.Employee> parent) {
            if(newNode.Value[0].lastEntrance > parent.Value[0].lastEntrance) {
                if(parent.right == null) {
                    parent.right = newNode;
                }
                else {
                    InsertInParent(newNode, parent.right);
                }
            }
            else {
                if(parent.left == null) {
                    parent.left = newNode;
                }
                else {
                    InsertInParent(newNode, parent.left);
                }
            }
        }

        public Employees.Employee[] Search(DateTime dateTime) {
            return FindNode(treeRoot, dateTime).Value;
        }
        public Employees.Employee[] SearchRange(DateTime dateTime1, DateTime dateTime2) {
            List<Employees.Employee> employeeRange = new List<Employees.Employee>();
            BinaryTreeNode<Employees.Employee> firstNode = FindNode(treeRoot, dateTime1);
            BinaryTreeNode<Employees.Employee> lastNode = FindNode(treeRoot, dateTime2);

            foreach(Employees.Employee employee in lastNode.Value) {
                employeeRange.Add(employee);
            }

            if(firstNode.left.Value[0].lastEntrance < dateTime2) {
                foreach(Employees.Employee employee in firstNode.left.Value) {
                    employeeRange.Add(employee);
                }
            }

            return employeeRange.ToArray();
        }

        BinaryTreeNode<Employees.Employee> FindNode(BinaryTreeNode<Employees.Employee> node, DateTime value) {
            DateTime nodeValue = node.Value[0].lastEntrance;
            if(nodeValue == value) {
                return node;
            }
            if(nodeValue < value) {
                if(node.right != null) {
                    return FindNode(node.right, value);
                }
            }
            if(nodeValue > value) {
                if(node.left != null) {
                    return FindNode(node.left, value);
                }
            }
            return null;
        }
    }
}
