using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class BridgePatternExercise : MonoBehaviour
    {
        private void Start()
        {
            AVehice bike = new Bike(new Produce(), new Assemble());
            bike.ManuFacture();

            AVehice bus = new Bus(new Produce(), new Assemble());
            bus.ManuFacture();
        }
    }

    public abstract class AVehice
    {
        protected IWorkshop produce;
        protected IWorkshop assemble;

        public AVehice(IWorkshop produce, IWorkshop assemble)
        {
            this.produce = produce;
            this.assemble = assemble;
        }

        public void ManuFacture()
        {
            produce.Work();
            assemble.Work();
        }
    }

    public class Bus : AVehice
    {
        public Bus(IWorkshop produce, IWorkshop assemble) : base(produce, assemble)
        {
            
        }
    }

    public class Bike : AVehice
    {
        public Bike(IWorkshop produce, IWorkshop assemble) : base(produce, assemble)
        {

        }
    }

    public interface IWorkshop
    {
        void Work();
    }

    public class Produce : IWorkshop
    {
        public void Work()
        {
            Debug.Log("Produce");
        }
    }

    public class Assemble: IWorkshop
    {
        public void Work()
        {
            Debug.Log("Assemble");
        }
    }
}
