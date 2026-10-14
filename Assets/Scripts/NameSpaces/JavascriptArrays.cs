using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Javascript {
    public class Array<T> {

        List<T> list = new();
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
            List<T> _temp = list;
            list.Clear();
            list.Add(grej);
            foreach(T item in _temp) {
                list.Add(item);
            }
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

