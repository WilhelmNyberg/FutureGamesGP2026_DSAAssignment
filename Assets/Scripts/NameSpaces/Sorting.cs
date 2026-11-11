using System;
using UnityEngine;
using static Employees;
using static UnityEngine.Rendering.DebugUI;

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

namespace Search {
    public static class LinearSearch {
        public static int SearchSingleValue(Employee[] array, DateTime value) {
            for(int i = 0; i < array.Length; i++) if(array[i].lastEntrance == value) return i;
            return -1;
        }
    }
    public static class BinarySearch {
        public static int SearchSingleValue(Employee[] array, DateTime value, int size/* size = -1: lowest index; size = 0: first index it can find; size = 1: highest index;*/) {
        

            int lowIndex = 0;
            int highIndex = array.Length - 1;
            int median = highIndex / 2;
            int loops = 0;

            while(median != highIndex) {
                loops++;
                if(loops >= array.Length) break;

                if(value < array[median].lastEntrance) {
                    highIndex = median - 1;
                    median = lowIndex + (highIndex - lowIndex) / 2;
                }
                else {
                    lowIndex = median + 1;
                    median = highIndex - (highIndex - lowIndex) / 2;
                }

                if(value == array[median].lastEntrance) {
                    if(size != 0) {
                        while (array[median].lastEntrance == array[median + size].lastEntrance) {
                            median += size;
                            if(median <= 0) {
                                median = 0;
                                break;
                            } else if(median >= array.Length - 1) {
                                median = array.Length - 1;
                                break;
                            }
                        }
                    }
                    return median;
                }
            }
            if(size == 0) return -1;
            return median;
        }

        public static Employee[] SearchValuesInRange(Employee[] array, DateTime lowValue, DateTime highValue) {
            

            int lowIndex = (SearchSingleValue(array, lowValue, -1) > -1) ? SearchSingleValue(array, lowValue, -1) : 0;
            int highIndex = (SearchSingleValue(array, highValue, 1) > -1) ? SearchSingleValue(array, highValue, 1) : 0;

            Employee[] newArray = new Employee[highIndex - lowIndex + 1];

            for (int i = 0; i < newArray.Length; i++) {
                newArray[i] = array[lowIndex + i]; 
            }


            
            return newArray;
        }
    }
}
