using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Javascript {
    public class Array<T> {

        List<T> list = new();
        public Array() {
            list = new();
        }
        public Array(int size) {
            list = new(size);
        }
        public Array(T[] items) {
            list = new();
            foreach(T item in items) {
                list.Add(item);
            }
        }
        public void Push(T grej) {
            list.Add(grej);
        }
        
        public T Unshift() {
            if(list.Count == 0) return default(T);

            T item = list[0];
            list.Remove(item);
            return item;
        }
        
        public T Pop() {
            T item = list[list.Count - 1];
            list.Remove(item);
            return item;
        }

        public void Shift(T grej) {
            /*List<T> _temp = list;
            list.Clear();
            list.Add(grej);
            foreach(T item in _temp) {
                list.Add(item);
            }

            list.Add(grej);*/
            for(int i = list.Count-1; i > 0-1; i--) {
                if(i == list.Count - 1) continue;
                list[i+1] = list[i];
            }
            list[0] = grej;
        }

        public T PeekAWP() {
            if(list.Count == 0) return default(T);
            return list[list.Count - 1];
        }
        public T SwingShotgun() {
            if(list.Count == 0) return default(T);
            return list[0];
        }

    }
}

