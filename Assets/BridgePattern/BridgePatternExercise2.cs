using System.Collections;
using System.Collections.Generic;
using NPS;
using UnityEngine;

public class BridgePatternExercise2 : MonoBehaviour
{
    private void Start()
    {
        Shape redCircle = new Circle(1, new Vector2(1, 1), new RedCircle());
        Shape blueCircle = new Circle(1, new Vector2(1, 1), new BlueCircle());

        redCircle.Draw();
        blueCircle.Draw();
    }

    public abstract class Shape
    {
        protected DrawAPI drawAPI;
        protected Shape(DrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }
        public abstract void Draw();
    }

    public class Circle : Shape
    {
        public float radius;
        public Vector2 center;

        public Circle(float radius, Vector2 center, DrawAPI drawAPI) : base(drawAPI)
        {
            this.radius = radius;
            this.center = center;
        }

        public override void Draw()
        {
            drawAPI.Draw(radius, center);
        }
    }

    public interface DrawAPI
    {
        void Draw(float radius, Vector2 center);
    }

    public class RedCircle : DrawAPI
    {
        public void Draw(float radius, Vector2 center)
        {
            Debug.Log("Red: " + radius + " / (" + center.x + ", " + center.y + ")");
        }
    }

    public class BlueCircle : DrawAPI
    {
        public void Draw(float radius, Vector2 center)
        {
            Debug.Log("Blue: " + radius + " / (" + center.x + ", " + center.y + ")");
        }
    }
}
