using System;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Secret Task", menuName = "Secret Task")]
    public class SecretTask : Task {

        [SerializeField]int[] list;
        bool sorted = false;

        public override void Execute() {
            
            sorted = false;
            int listLength = list.Length;
            while(!sorted) {
                sorted = true;
                for(int i = 0; i < listLength; i++) {
                    
                    CompareList(list, i);
                }
                listLength--;
            }
        }

        void PrintListValues() {
            string log = "";
            foreach (int number in list) {
                log += number.ToString();
                log += " ";
            }
            Debug.Log(log);
        }

        void CompareList(int[] list, int index) {
            if(index + 1 >= list.Length) return;
            if(list[index] > list[index + 1]) {
                sorted = false;
                int temp = list[index];
                list[index] = list[index + 1];
                list[index + 1] = temp;
                PrintListValues();
                return;
            }
            else {
                PrintListValues();
                return;
            }
        }
    }
}
