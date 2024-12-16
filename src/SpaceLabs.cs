using System;
using UnityEngine;

namespace SpaceLabs {
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class SpaceLabs : MonoBehaviour
    {
        void Start() {
            Log("Body Order Check");
            foreach (CelestialBody body in FlightGlobals.Bodies)
            {
                Log($"{body.name}, Index {FlightGlobals.GetBodyIndex(body)}");
            }
        }

        void Log(string msg) {
            Debug.Log($"[SpaceLabs]: {msg}");
        }
    }
}


