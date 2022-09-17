using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class CompositePatternExercise : MonoBehaviour
    {
        private void Start()
        {
            var button = new Button("button");
            var label = new Label("label");
            var dialog = new Dialog("dialog");

            dialog.Add(button);
            dialog.Add(label);

            dialog.Remove(button);
        }

        public class View
        {
            private List<View> children = new List<View>();
            private View parent;

            private string name;

            public View()
            {

            }

            public View(string name)
            {
                this.name = name;
            }

            public void Add(View view)
            {
                children.Add(view);
            }

            public void Remove(View view)
            {
                children.Remove(view);
            }
        }

        public class Button: View
        {
            public Button() : base()
            {

            }

            public Button(string name) : base(name)
            {

            }
        }

        public class Label: View
        {
            public Label() : base()
            {

            }

            public Label(string name) : base(name)
            {

            }
        }

        public class Dialog: View
        {
            public Dialog() : base()
            {

            }

            public Dialog(string name) : base(name)
            {

            }
        }
    }
}