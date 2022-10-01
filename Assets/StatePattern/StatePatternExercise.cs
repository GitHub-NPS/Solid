using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class StatePatternExercise : MonoBehaviour
    {
        private void Start()
        {
            User user = new User(true);
            User admin = new User(true);

            Document document = new Document(user);
            document.ChangeState(new Draft(document));
            //document.render();
            document.publish();
        }

        public class User
        {
            public bool isAdmin = false;
            public User(bool isAdmin)
            {
                this.isAdmin = isAdmin;
            }
        }

        public class Document
        {
            public User user;
            private State state;

            public Document(User user)
            {
                this.user = user;
            }

            public void ChangeState(State state)
            {
                Debug.Log("State: " + state.ToString());
                this.state = state;
            }

            public void render()
            {
                state.render();
            }

            public void publish()
            {
                state.publish();
            }
        }

        public abstract class State
        {
            protected Document document;
            public State(Document document)
            {
                this.document = document;
            }

            public abstract void render();
            public abstract void publish();
        }

        public class Draft : State
        {
            public Draft(Document document) : base(document)
            {
            }

            public override void render()
            {
                document.ChangeState(new Moderation(document));
            }

            public override void publish()
            {
                if (document.user.isAdmin)
                {
                    document.ChangeState(new Published(document));
                }
                else
                {
                    Debug.Log("You are not Admin");
                }
            }
        }

        public class Published : State
        {
            public Published(Document document) : base(document)
            {
            }

            public override void render()
            {
                Debug.Log("Error");
            }

            public override void publish()
            {
                Debug.Log("Error");
            }
        }

        public class Moderation : State
        {
            public Moderation(Document document) : base(document)
            {
            }

            public override void render()
            {
                Debug.Log("Error");
            }

            public override void publish()
            {
                document.ChangeState(new Published(document));
            }
        }
    }
}