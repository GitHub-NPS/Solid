using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class StrategyPatternExercise2 : MonoBehaviour
    {
        private void Start()
        {
            SortedList<string> sortedList = new SortedList<string>();
            sortedList.Add("Java Core");
            sortedList.Add("Java Design Pattern");
            sortedList.Add("Java Library");
            sortedList.Add("Java Framework");

            sortedList.setSortStrategy(new QuickSort<string>());
            sortedList.sort();

            sortedList.setSortStrategy(new MergeSort<string>());
            sortedList.sort();
        }

        public class SortedList<T>
        {
            private SortStrategy<T> strategy;
            private List<T> items = new List<T>();

            public void setSortStrategy(SortStrategy<T> strategy)
            {
                this.strategy = strategy;
            }

            public void Add(T name)
            {
                items.Add(name);
            }

            public void sort()
            {
                strategy.sort(items);
            }
        }

        public interface SortStrategy<T>
        {
            void sort(List<T> items);
        }

        public class QuickSort<T> : SortStrategy<T>
        {
            public void sort(List<T> items)
            {
                Debug.Log("Quick Sort");
            }
        }

        public class MergeSort<T> : SortStrategy<T>
        {
            public void sort(List<T> items)
            {
                Debug.Log("Merge Sort");
            }
        }

        public class SelectionSort<T> : SortStrategy<T>
        {
            public void sort(List<T> items)
            {
                Debug.Log("Selection Sort");
            }
        }
    }
}