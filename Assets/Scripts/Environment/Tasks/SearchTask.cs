using Environment.Tasks;
using System;
using UnityEngine;
using Search;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SearchTask", menuName = "Search In Json")]
public class SearchTask : Task {
    [SerializeField] Employees employeeData;

    public override void Execute() {
        System.Diagnostics.Stopwatch time = System.Diagnostics.Stopwatch.StartNew();
        int index = BinarySearch.SearchSingleValue(employeeData.workers, new DateTime(2234, 1, 9, 23, 53, 01), 1);
        time.Stop();
        Debug.Log($"Index of Employee is: { index}");
        Debug.Log($"Emplyee is : {employeeData.workers[index].name}");;
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");
        Debug.Log($"");

        time.Reset();
        time.Start();
        Employees.Employee[] workersInRange = BinarySearch.SearchValuesInRange(employeeData.workers, new DateTime(1970, 1, 1, 0, 0, 1), new DateTime(2234, 8, 6, 17, 19, 8));
        time.Stop();
        Debug.Log($"Range found");
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");
        Debug.Log($"Amount of Employees: {workersInRange.Length}");
        foreach (Employees.Employee worker in workersInRange) {
            Debug.Log($"Employee : {worker.name}");
        }
    }
}
