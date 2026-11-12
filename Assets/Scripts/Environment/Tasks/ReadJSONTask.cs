using Environment.Tasks;
using Javascript;
using System;
using System.Text.Json;
using System.IO;
using UnityEngine;
using StoringData;

[CreateAssetMenu(fileName = "Read JSON", menuName = "Tasks")]
public class ReadJSONTask : Task
{
    [SerializeField] TextAsset JSONData;
    [SerializeField] Employees employeeData;

    public override void Execute() {
        if(JSONData == null) { Debug.Log("No JSON Data"); return; }
        string json = JSONData.text;
        employeeData.workers = JsonUtility.FromJson<Employees.EmployeeArray>(json).employees;
        //employeeData.StringifiedToEmployee(temp);

        foreach(Employees.Employee e in employeeData.workers) {
            e.lastEntrance = DateTime.Parse(e.lastEntranceInEngineRoom);
            e.lastExit = DateTime.Parse(e.lastExitFromEngineRoom);
        }

        employeeData.workersTree = new BinaryTree(employeeData.workers);

        Sort.Sorting.HeapSort(employeeData.workers);
    }
}
