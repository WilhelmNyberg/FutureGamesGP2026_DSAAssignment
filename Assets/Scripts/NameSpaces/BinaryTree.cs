using UnityEngine;
using System.Collections.Generic;
using System;

namespace StoringData {
    public class BinaryTreeNode<T> {
        T nodeData = default(T);
        public T Value { get { return nodeData; } }
        public BinaryTreeNode<T> left = null;
        public BinaryTreeNode<T> right = null;
        public BinaryTreeNode(T data) {
            nodeData = data;
        }
    }
    public class BinaryTree<T> {

        BinaryTreeNode<T> treeRoot = null;

        int treeHeight = 0; 

        BinaryTree(T root){
            treeRoot = new BinaryTreeNode<T>(root);
        }
        BinaryTree(T[] initialData) {
            int median = initialData.Length / 2;
            treeRoot = new BinaryTreeNode<T>(initialData[median]);
            for(int i = 0; i < initialData.Length; i++) {
                if(i == median) continue;
                Insert(initialData[i]);
            }
        }
        public void Insert(T data) {
            BinaryTreeNode<T> newNode = new BinaryTreeNode<T>( data);
        }

        void InsertInParent(BinaryTreeNode<T> newNode, BinaryTreeNode<T> parent) {
            if(newNode.Value < parent.Value) {

            }
        }
    }
}
