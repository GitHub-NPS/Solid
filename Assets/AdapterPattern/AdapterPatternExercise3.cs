using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdapterPatternExercise3 : MonoBehaviour
{
    private void Start()
    {
        var hole = new RoundHole(5);
        var rpeg = new RoundPeg(5);
        hole.fits(rpeg); // true

        var small_sqpeg = new SquarePeg(5);
        var large_sqpeg = new SquarePeg(10);
        // hole.fits(small_sqpeg); // cannot

        var small_sqpeg_adapter = new SquarePegAdapter(small_sqpeg);
        var large_sqpeg_adapter = new SquarePegAdapter(large_sqpeg);

        hole.fits(small_sqpeg_adapter); // true
        hole.fits(large_sqpeg_adapter); // false
    }

    public class RoundHole
    {
        private float radius;

        public RoundHole()
        {

        }

        public RoundHole(float radius)
        {
            this.radius = radius;
        }

        public float GetRadius()
        {
            return radius;
        }

        public bool fits(RoundPeg peg)
        {
            return radius >= peg.GetRadius();
        }
    }

    public class RoundPeg
    {
        private float radius;

        public RoundPeg()
        {

        }

        public RoundPeg(float radius)
        {
            this.radius = radius;
        }

        public virtual float GetRadius()
        {
            return radius;
        }
    }

    public class SquarePeg
    {
        private float width;

        public SquarePeg(float width)
        {
            this.width = width;
        }

        public float GetWidth()
        {
            return width;
        }
    }

    public class SquarePegAdapter : RoundPeg
    {
        private SquarePeg peg;

        public SquarePegAdapter() : base()
        {

        }

        public SquarePegAdapter(SquarePeg peg)
        {
            this.peg = peg;
        }

        public override float GetRadius()
        {
            return peg.GetWidth() * Mathf.Sqrt(2) / 2;
        }
    }
}
