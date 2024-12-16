using System;
using Contracts;
using UnityEngine;

namespace SpaceLabs {
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class SpaceLabs : MonoBehaviour
    {
        void Start() {
            Log("Body Order Check (FlightGlobals)");
            foreach (CelestialBody body in FlightGlobals.Bodies)
            {
                Log($"{body.name}, Index {FlightGlobals.GetBodyIndex(body)}");
            }

            Log("Body Order Check (Contract.GetBodies)");
            var bodies = FlightGlobals.Bodies;
            bodies.Sort((CelestialBody b1, CelestialBody b2) => b1.scienceValues.RecoveryValue.CompareTo(b2.scienceValues.RecoveryValue));
            for (int i = 0; i < bodies.Count; i++)
            {
                Log($"{bodies[i].name}, Index {i}");            
            }
        }

        void Log(string msg) {
            Debug.Log($"[SpaceLabs]: {msg}");
        }
    }
}


