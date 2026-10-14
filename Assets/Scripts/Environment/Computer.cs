using Environment.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private Task testTask = null; // Put your stack/queue here :)

        [SerializeField] private Queue<Task> taskQueue = new();

        public void OnInteract() {
            taskQueue.Dequeue().Execute();
        }
    }
}
