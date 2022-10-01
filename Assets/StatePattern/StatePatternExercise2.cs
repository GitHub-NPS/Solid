using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class StatePatternExercise2 : MonoBehaviour
    {
        private void Start()
        {
            AudioPlayer player = new AudioPlayer();
            player.Play();
        }

        public class AudioPlayer
        {
            public bool playing = false;
            private State state;

            public AudioPlayer()
            {
                this.state = new ReadyState(this);
            }

            public void changeState(State state)
            {
                this.state = state;
                Debug.Log(state.ToString());
            }

            public void startPlayback()
            {
                Debug.Log("Start");
                playing = true;
            }

            public void stopPlayback()
            {
                Debug.Log("Stop");
                playing = false;
            }

            public void Lock()
            {
                state.Lock();
            }

            public void Play()
            {
                state.Play();
            }
        }

        public abstract class State
        {
            protected AudioPlayer player;

            public State(AudioPlayer player)
            {
                this.player = player;
            }

            public abstract void Lock();
            public abstract void Play();
        }

        public class LockedState : State
        {
            public LockedState(AudioPlayer player) : base(player)
            {
            }

            public override void Lock()
            {
                if (player.playing)
                {
                    player.changeState(new PlayingState(player));
                }
                else
                {
                    player.changeState(new ReadyState(player));
                }
            }

            public override void Play()
            {
                
            }
        }

        public class ReadyState : State
        {
            public ReadyState(AudioPlayer player) : base(player)
            {
            }

            public override void Lock()
            {
                player.changeState(new LockedState(player));
            }

            public override void Play()
            {
                player.startPlayback();
                player.changeState(new PlayingState(player));
            }
        }

        public class PlayingState : State
        {
            public PlayingState(AudioPlayer player) : base(player)
            {
            }

            public override void Lock()
            {
                player.changeState(new LockedState(player));
            }

            public override void Play()
            {
                player.stopPlayback();
                player.changeState(new ReadyState(player));
            }
        }
    }
}