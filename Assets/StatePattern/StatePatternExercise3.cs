using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class StatePatternExercise3 : MonoBehaviour
    {
        private void Start()
        {
            Document context = new Document();

            context.setState(new NewState());
            context.applyState();

            context.setState(new SubmitedState());
            context.applyState();

            context.setState(new ApprovedState());
            context.applyState();
        }

        public class Document
        {
            private State state;

            public void setState(State state)
            {
                this.state = state;
            }

            public void applyState()
            {
                this.state.handleRequest();
            }
        }

        public interface State
        {
            void handleRequest();
        }

        public class NewState : State
        {
            public void handleRequest()
            {
                Debug.Log("Create a new document");
            }
        }

        public class SubmitedState : State
        {
            public void handleRequest()
            {
                Debug.Log("Submit");
            }
        }

        public class ApprovedState : State
        {
            public void handleRequest()
            {
                Debug.Log("Approved");
            }
        }

        public class RejectedState : State
        {
            public void handleRequest()
            {
                Debug.Log("Rejected");
            }
        }
    }
}