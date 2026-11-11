using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace StoringData {
    
    public class BinaryTreeNode<T> {
        [SerializeField] List<T> nodeData;
        public T[] Value { get { return nodeData.ToArray(); } }
        public BinaryTreeNode<T> left = null;
        public BinaryTreeNode<T> right = null;
        public BinaryTreeNode(T data) {
            nodeData = new();
            nodeData.Add(data);
        }
        public void Add(T data) {
            nodeData.Add(data);
        }
    }
    [Serializable]
    public class BinaryTree {

        public BinaryTreeNode<Employees.Employee> treeRoot = null;
        
        int treeHeight = 0; 

        public BinaryTree(Employees.Employee root){
            treeRoot = new BinaryTreeNode<Employees.Employee>(root);
        }
        public BinaryTree(Employees.Employee[] initialData) {
            int median = initialData.Length / 2;
            treeRoot = new BinaryTreeNode<Employees.Employee>(initialData[median]);
            for(int i = median; i < initialData.Length; i++) {
                if(i == median) continue;
                Insert(initialData[i]);
            }
            for(int i = median; i > -1; i--) {
                if(i == median) continue;
                Insert(initialData[i]);
            }
        }
        public void Insert(Employees.Employee data) {
            BinaryTreeNode<Employees.Employee> newNode = new BinaryTreeNode<Employees.Employee>(data);
            InsertInParent(newNode, treeRoot);
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
            else if (newNode.Value[0].lastEntrance < parent.Value[0].lastEntrance) {
                if(parent.left == null) {
                    parent.left = newNode;
                }
                else {
                    InsertInParent(newNode, parent.left);
                }
            }
            else if (newNode.Value[0].lastEntrance == parent.Value[0].lastEntrance) {
                parent.Add(newNode.Value[0]);
            }
        }

        public Employees.Employee[] Search(DateTime dateTime) {
            return FindNode(treeRoot, dateTime).Value;
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
        public Employees.Employee[] SearchRange(DateTime dateTime1, DateTime dateTime2) {
            List<Employees.Employee> employeeRange = new List<Employees.Employee>();

            FindNodesInRange(employeeRange, treeRoot, dateTime1, dateTime2);

            return employeeRange.ToArray();
        }


        void FindNodesInRange (List<Employees.Employee> list, BinaryTreeNode<Employees.Employee> node, DateTime d1, DateTime d2) {
            DateTime nodeValue = node.Value[0].lastEntrance;

            if(nodeValue >= d1 && node.left != null) FindNodesInRange(list, node.left, d1, d2);
            if(nodeValue >= d1 && nodeValue <= d2) {
                foreach (Employees.Employee employee in node.Value) {
                    list.Add(employee);
                }
            }
            if(nodeValue <= d2 && node.right != null) FindNodesInRange(list, node.right, d1, d2);
        }

    }
}
