
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using System;

namespace akaUdon
{
    public class UdonAnalogClock : UdonSharpBehaviour
    {
        
        #region private vars
        private Animator Clock; //animator must be on the same gameobject as the clock mesh
        private const string HourHand = "hour"; //hour and min are the names of the floats inside the animator
        private const string MinHand = "min";
        private float UpdateTime = 15f; //amount of time between each update in seconds.
        #endregion

        #region Methods
        void Start()
        {
            Clock = this.GetComponent<Animator>(); // assigns the animator on the gameobject to the aniamtor variable in this script.
            _writeTime(); //calls the method below
        }

        public void _writeTime()
        {
            float hour = (DateTime.Now.Hour % 12) / 12f; //gets the current hour from system time, converts it from military, then converts to a franction between 0 and 1;
            float minutes = DateTime.Now.Minute / 60f; //gets the current minute from system time, then converts to a franction between 0 and 1;
            hour += minutes / 12;
            Clock.SetFloat(HourHand, hour); //sets the respective float value in the animator
            Clock.SetFloat(MinHand, minutes); //sets the respective float value in the animator
            SendCustomEventDelayedSeconds(nameof(_writeTime), UpdateTime); //calls itself again after the amount of time in UpdateTime is finished.
        }
        #endregion
    }
}
