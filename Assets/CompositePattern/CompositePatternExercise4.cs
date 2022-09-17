using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class CompositePatternExercise4 : MonoBehaviour
    {
        private void Start()
        {
            CompoundGraphic all = new CompoundGraphic();

            all.Add(new Dot(1, 2));
            all.Add(new Circle(5, 3, 10));

            all.Draw();
        }

        public interface IGraphic
        {
            void Move(int x, int y);
            void Draw();
        }

        public class Dot : IGraphic
        {
            private int x;
            private int y;

            public Dot()
            {

            }

            public Dot(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public virtual void Draw()
            {
                Debug.Log("(" + x + ", " + y + ")");
            }

            public void Move(int x, int y)
            {
                this.x += x;
                this.y += y;
            }
        }

        public class Circle : Dot
        {
            private float radius;

            public Circle() : base()
            {

            }

            public Circle(int x, int y, float radius) : base(x, y)
            {
                this.radius = radius;
            }

            public override void Draw()
            {
                base.Draw();
                Debug.Log(radius);
            }
        }

        public class CompoundGraphic : IGraphic
        {
            private List<IGraphic> children = new List<IGraphic>();

            public void Draw()
            {
                foreach (var child in children)
                {
                    child.Draw();
                }
            }

            public void Move(int x, int y)
            {
                foreach (var child in children)
                {
                    child.Move(x, y);
                }
            }

            public void Add(IGraphic child)
            {
                children.Add(child);
            }

            public void Remove(IGraphic child)
            {
                children.Remove(child);
            }
        }
    }
}