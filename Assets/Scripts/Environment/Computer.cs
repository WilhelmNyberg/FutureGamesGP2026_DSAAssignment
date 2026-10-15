using Environment.Tasks;
using Custom.Queue;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {

        [SerializeField] private Queue<Task> taskQueue = new();

        public void OnInteract() {
            if(taskQueue.Count == 0) return;
            Task currentTask = taskQueue.Dequeue();
            Debug.Log($"Executed task: {currentTask.name}");
            currentTask.Execute();
        }
    }
}
