using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class StrategyPatternExercise : MonoBehaviour
    {
        private void Start()
        {
            Context context = new Context();
            Action action = (Action)Random.Range(0, 3);
            switch (action)
            {
                case Action.Addition:
                    context.setStrategy(new ConcreteStrategyAdd());
                    break;
                case Action.Substraction:
                    context.setStrategy(new ConcreteStrategySubtract());
                    break;
                case Action.Multiplication:
                    context.setStrategy(new ConcreteStrategyMultiply());
                    break;
            }

            Debug.Log(action + ": " + context.executeStrategy(5, 3));
        }

        public enum Action
        {
            Addition = 0,
            Substraction = 1,
            Multiplication = 2,
        }

        public class Context
        {
            private Strategy strategy;

            public void setStrategy(Strategy strategy)
            {
                this.strategy = strategy;
            }

            public int executeStrategy(int a, int b)
            {
                return strategy.execute(a, b);
            }
        }

        public interface Strategy
        {
            int execute(int a, int b);
        }

        public class ConcreteStrategyAdd : Strategy
        {
            public int execute(int a, int b)
            {
                return a + b;
            }
        }

        public class ConcreteStrategySubtract : Strategy
        {
            public int execute(int a, int b)
            {
                return a - b;
            }
        }

        public class ConcreteStrategyMultiply : Strategy
        {
            public int execute(int a, int b)
            {
                return a * b;
            }
        }
    }
}