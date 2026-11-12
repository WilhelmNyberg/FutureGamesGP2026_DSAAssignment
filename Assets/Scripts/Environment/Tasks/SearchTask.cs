using Environment.Tasks;
using Search;
using System;
using System.Collections.Generic;
using UnityEngine;
using static Employees;

[CreateAssetMenu(fileName = "SearchTask", menuName = "Search In Json")]
public class SearchTask : Task {
    [SerializeField] Employees employeeData;

    public override void Execute() {
        System.Diagnostics.Stopwatch time = System.Diagnostics.Stopwatch.StartNew();
        /*int index = BinarySearch.SearchSingleValue(employeeData.workers, new DateTime(2234, 8, 3, 3 , 21 , 18), -1);
        time.Stop();
        Debug.Log($"Binary Search Complete");
        Debug.Log($"Index of Employee is: { index}");
        Debug.Log($"Emplyee is : {employeeData.workers[index].name}");;
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");

        time.Reset();
        time.Start();
        index = LinearSearch.SearchSingleValue(employeeData.workers, new DateTime(2234, 8, 3, 03, 21, 18));
        time.Stop();
        Debug.Log($"Linear Search Complete");
        Debug.Log($"Index of Employee is: {index}");
        Debug.Log($"Emplyee is : {employeeData.workers[index].name}"); ;
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");

        time.Reset();
        time.Start();
        Employees.Employee employee = employeeData.workersTree.Search(new DateTime(2234, 8, 3, 03, 21, 18))[0];
        time.Stop();
        Debug.Log($" Search in tree Complete");
        Debug.Log($"Emplyee is : {employee.name}"); ;
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");
        
        time.Reset();
        time.Start();*/
        Employees.Employee[] employees = employeeData.workersTree.SearchRange(new DateTime(2234, 8, 9, 22, 0, 0), new DateTime(2234, 8, 9, 23, 0, 0));
        time.Stop();
        Debug.Log($"Range Search in tree Complete");
        Debug.Log($"The Employees are:"); 
        foreach(Employees.Employee employee in employees) {
            Debug.Log(employee.name+ " - " + employee.lastEntranceInEngineRoom);
        }
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");

        time.Reset();
        time.Start();
        Employees.Employee[] workersInRange = BinarySearch.SearchValuesInRange(employeeData.workers, new DateTime(2234, 8, 9, 22, 0, 0), new DateTime(2234, 8, 9, 23, 0, 0));
        time.Stop();
        Debug.Log($"Range found");
        Debug.Log($"Ticks elapsed:{time.ElapsedTicks}");
        foreach (Employees.Employee worker in workersInRange) {
            Debug.Log(worker.name + " - " + worker.lastEntranceInEngineRoom);
        }
    }
}
