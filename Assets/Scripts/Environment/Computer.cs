using Environment.Tasks;
using Custom.Queue;
using UnityEngine;
using System;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {

        [SerializeField] private Queue<Task> taskQueue = new();
        [SerializeField] Employees employeeData;
        void Start() {
            employeeData.workers = null;
        }

        public void OnInteract() {
            if(taskQueue.Count == 0) return;
            Task currentTask = taskQueue.Dequeue();
            Debug.Log($"Executed task: {currentTask.name}");
            currentTask.Execute();
        }
    }
}
