using Environment.Tasks;
using System;
using UnityEngine;
using Search;

[CreateAssetMenu(fileName = "SearchTask", menuName = "Search In Json")]
public class SearchTask : Task {
    [SerializeField] Employees employeeData;

    public override void Execute() {
        int index = BinarySearch.SearchSingleValue(employeeData.workers, new DateTime(1970, 1, 1, 0, 0, 0), 0);
        Debug.Log($"Index of Employee is: { index}");
        Debug.Log($"Emplyee is : {employeeData.workers[index].name}");

        Employees.Employee[] workersInRange = BinarySearch.SearchValuesInRange(employeeData.workers, new DateTime(1970, 1, 1, 0, 0, 0), new DateTime(1970, 1, 1, 0, 0, 0));

        Debug.Log($"Amount of Employees: {workersInRange.Length}");
        foreach (Employees.Employee worker in workersInRange) {
            Debug.Log($"Employee : {worker.name}");
        }
    }
}
