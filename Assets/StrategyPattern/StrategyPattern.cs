using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class StrategyPattern : MonoBehaviour
    {
        private void Start()
        {
            var context = new Context();

            Debug.Log("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Debug.Log("------------------------------------------");

            Debug.Log("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }

        public class Context
        {
            private IStrategy _strategy;

            public Context()
            { }

            public Context(IStrategy strategy)
            {
                this._strategy = strategy;
            }

            public void SetStrategy(IStrategy strategy)
            {
                this._strategy = strategy;
            }

            public void DoSomeBusinessLogic()
            {
                Debug.Log("Context: Sorting data using the strategy (not sure how it'll do it)");
                var result = this._strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

                string resultStr = string.Empty;
                foreach (var element in result as List<string>)
                {
                    resultStr += element + ",";
                }

                Debug.Log(resultStr);
            }
        }

        public interface IStrategy
        {
            object DoAlgorithm(object data);
        }

        public class ConcreteStrategyA : IStrategy
        {
            public object DoAlgorithm(object data)
            {
                var list = data as List<string>;
                list.Sort();

                return list;
            }
        }

        public class ConcreteStrategyB : IStrategy
        {
            public object DoAlgorithm(object data)
            {
                var list = data as List<string>;
                list.Sort();
                list.Reverse();

                return list;
            }
        }
    }
}