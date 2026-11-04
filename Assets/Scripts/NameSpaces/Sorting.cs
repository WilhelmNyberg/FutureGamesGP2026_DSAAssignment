using System;
using UnityEngine;
using static Employees;

namespace Sort {
    public class Sorting
    {
        public static int loops = 0;
        public static void HeapSort(Employee[] array) {

            int arrayLength = array.Length;

            // Find max heap
            for(int i = arrayLength/2 - 1; i > 0; i--) {
                Heapify(array, i, arrayLength);
                loops++;
            }

            while (arrayLength > 0) {
                Heapify(array, 0, arrayLength);
                Employee temp = array[0];
                array[0] = array[arrayLength - 1];
                array[arrayLength - 1] = temp;
                arrayLength--;
                loops++;
            }
            for(int i = 0; i < array.Length; i++) {
                if(i == 0) continue;
                if(DateTime.Compare(array[i].lastEntrance, array[i-1].lastEntrance) < 0) {
                    Debug.Log($"List not sorted at index {i}");
                    break;
                }
            }
            Debug.Log($"Sorted in {loops} loops");
            loops = 0;
        }

        public static void Heapify(Employee[] array, int index, int maxValue) {
            int bigIndex = index;

            int childIndex1 = (index * 2 + 1 < maxValue) ? index * 2 + 1 : index;
            int childIndex2 = (index * 2 + 2 < maxValue) ? index * 2 + 2 : index;

            if(DateTime.Compare(array[childIndex1].lastEntrance, array[bigIndex].lastEntrance) > 0) bigIndex = childIndex1;
            if(DateTime.Compare(array[childIndex2].lastEntrance, array[bigIndex].lastEntrance) > 0) bigIndex = childIndex2;

            loops++;

            if (bigIndex != index)
            {
                Employee temp = array[bigIndex];
                array[bigIndex] = array[index];
                array[index] = temp;
                Heapify(array, bigIndex, maxValue);
            }
        }
    }
}
