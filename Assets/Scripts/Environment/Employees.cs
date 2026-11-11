using StoringData;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Employees", menuName = "Employees")]
public class Employees : ScriptableObject
{
    [Serializable]
    public class Employee {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public DateTime lastEntrance;
        public string lastEntranceInEngineRoom;
        public DateTime lastExit;
        public string lastExitFromEngineRoom;
    }
    public class EmployeeArray {
        public Employee[] employees;
    }
    public Employee[] workers;
    [Header("Tree")]
    [SerializeField]public BinaryTree workersTree;

}
