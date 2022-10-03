using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class TemplateMethodPattern : MonoBehaviour
    {
        private void Start()
        {
            AbstractClass c1 = new ConcreteClass1();
            c1.TemplateMethod();

            AbstractClass c2 = new ConcreteClass1();
            c2.TemplateMethod();
        }

        public abstract class AbstractClass
        {
            public void TemplateMethod()
            {
                this.BaseOperation1();
                this.RequiredOperations1();
                this.BaseOperation2();
                this.Hook1();
                this.RequiredOperation2();
                this.BaseOperation3();
                this.Hook2();
            }

            protected void BaseOperation1()
            {
                Debug.Log("AbstractClass says: I am doing the bulk of the work");
            }

            protected void BaseOperation2()
            {
                Debug.Log("AbstractClass says: But I let subclasses override some operations");
            }

            protected void BaseOperation3()
            {
                Debug.Log("AbstractClass says: But I am doing the bulk of the work anyway");
            }

            protected abstract void RequiredOperations1();

            protected abstract void RequiredOperation2();

            protected virtual void Hook1() { }

            protected virtual void Hook2() { }
        }

        public class ConcreteClass1 : AbstractClass
        {
            protected override void RequiredOperations1()
            {
                Debug.Log("ConcreteClass1 says: Implemented Operation1");
            }

            protected override void RequiredOperation2()
            {
                Debug.Log("ConcreteClass1 says: Implemented Operation2");
            }
        }

        public class ConcreteClass2 : AbstractClass
        {
            protected override void RequiredOperations1()
            {
                Debug.Log("ConcreteClass2 says: Implemented Operation1");
            }

            protected override void RequiredOperation2()
            {
                Debug.Log("ConcreteClass2 says: Implemented Operation2");
            }

            protected override void Hook1()
            {
                Debug.Log("ConcreteClass2 says: Overridden Hook1");
            }
        }
    }
}