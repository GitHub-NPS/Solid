using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class BridgePatternExercise3 : MonoBehaviour
    {
        private void Start()
        {
            AShape circle = new Circle();
            circle.SetColor(new Red());
            circle.Draw();

            AShape square = new Square();
            square.SetColor(new Blue());
            square.Draw();
        }

        public abstract class AShape
        {
            IColor color;

            public void SetColor(IColor color)
            {
                this.color = color;
            }

            public virtual void Draw()
            {
                color.Draw();
            }
        }

        public class Circle: AShape
        {
            public override void Draw()
            {
                Debug.Log("Circle");

                base.Draw();
            }
        }

        public class Square: AShape
        {
            public override void Draw()
            {
                Debug.Log("Square");

                base.Draw();
            }
        }

        public interface IColor
        {
            void Draw();
        }

        public class Red : IColor
        {
            public void Draw()
            {
                Debug.Log("Red");
            }
        }

        public class Blue : IColor
        {
            public void Draw()
            {
                Debug.Log("Blue");
            }
        }
    }
}
