using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class BridgePatternExercise4 : MonoBehaviour
    {
        private void Start()
        {
            Remote remote = new Remote(new Tv());
            remote.TogglePower();

            AdvancedRemote advance = new AdvancedRemote(new Radio());
            advance.Mute();
        }
    }

    public class Remote
    {
        protected IDevice device;

        public Remote(IDevice device)
        {
            this.device = device;
        }

        public void TogglePower()
        {
            if (device.IsEnable())
            {
                device.Disable();
            }
            else
            {
                device.Enable();
            }
        }
    }

    public class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device) : base(device)
        {
        }

        public void Mute()
        {
            device.SetVolume(0);
        }
    }

    public interface IDevice
    {
        bool IsEnable();
        void Enable();
        void Disable();
        void SetVolume(float value);
    }

    public class Device : IDevice
    {
        private bool enable = false;
        private float volume = 0;

        public void Disable()
        {
            enable = false;
        }

        public void Enable()
        {
            enable = true;
        }

        public bool IsEnable()
        {
            return enable;
        }

        public void SetVolume(float value)
        {
            volume = value;
        }
    }

    public class Radio: Device
    {

    }

    public class Tv: Device
    {

    }
}