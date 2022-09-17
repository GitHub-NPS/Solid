using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class AdapterPatternExercise : MonoBehaviour
    {
        public class Square
        {
            public int Side;
        }

        public interface IRectangle
        {
            int Area();
        }

        public class Rectangle : IRectangle
        {
            public int Width;

            public int Height;

            public int Area()
            {
                return Width * Height;
            }
        }

        public class SquareToRectangle : Rectangle
        {
            private Square square;

            public SquareToRectangle(Square square)
            {
                this.square = square;

                Width = square.Side;
                Height = square.Side;
            }
        }

        private void Start()
        {
            Square square = new Square()
            {
                Side = 5
            };

            var rec = new SquareToRectangle(square);
            Debug.Log(rec.Area());
        }
    }
}