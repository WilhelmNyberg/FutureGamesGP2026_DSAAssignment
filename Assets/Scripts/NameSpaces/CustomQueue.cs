using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

namespace Custom.Queue {
    [Serializable]
    public class Queue<T> {

        [SerializeField] List<T> queue = new();

        public Queue() {
            queue = new List<T>();
        }
        public Queue(int queueCapacity) {
            queue = new List<T>(queueCapacity);
        }
        public Queue(List<T> premadeQueue) {
            queue = premadeQueue;
        }

        public void Enqueue(T item) {
            queue.Add(item);
        }

        public T Dequeue() {
            if(queue.Count == 0) return default(T);
            T item = queue[0];
            queue.RemoveAt(0);
            return item;
        }
        public T Remove(int index) {
            if(queue.Count == 0||index < 0 || index > queue.Count-1) return default(T);
            T item = queue[index];
            queue.RemoveAt(index);
            return item;
        }

        public T Peek() {
            if(queue.Count == 0) return default(T);
            return queue[0];
        }

        public T Peek(int index) {
            if(queue.Count == 0 || index < 0 || index > queue.Count - 1) return default(T);
            return queue[index];
        }

        public int Count { get { return queue.Count; } }
        public int length { get { return queue.Count; } }
    }
}

