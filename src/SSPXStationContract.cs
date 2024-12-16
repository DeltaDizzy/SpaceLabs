using System.Collections.Generic;
using System.Linq;
using Contracts;
using Contracts.Parameters;
using UnityEngine;

namespace SpaceLabs 
{
    public class SSPXStationContract : Contract
    {
        private float reward = 1;

        private List<CelestialBody> sortedBodies = FlightGlobals.Bodies;
        private CelestialBody TargetBody {
            get {
                // next body kerbin that has been orbited
                var orbitedbodies = ProgressTracking.Instance.celestialBodyNodes
                                    .Where(tree => tree.orbit.IsComplete)
                                    .Select(tree => tree.Body);
                CelestialBody star = sortedBodies.Find(b => b.name is "Sun");
                if (star != null) // we havent processed this yet
                {
                    sortedBodies.Remove(star);
                    sortedBodies.Sort((CelestialBody b1, CelestialBody b2) => b1.scienceValues.RecoveryValue.CompareTo(b2.scienceValues.RecoveryValue));

                }
                var validBodies = sortedBodies.Intersect(orbitedbodies);
                return validBodies.First();
            }
        }
        public float NumberOfYears => numberOfYears;

        private float failure = 1;
        private float numberOfYears = 1;
        private float advance = 1;

        protected override bool Generate()
        {
            base.SetExpiry();
            base.SetScience(reward, TargetBody);
            base.SetDeadlineYears( NumberOfYears,  TargetBody);
            base.SetReputation( reward,  failure,  TargetBody);
            base.SetFunds( advance,  reward,  failure, TargetBody);
            return true; 
        }

        void Log(string msg) {
            Debug.Log($"[SpaceLabs]: {msg}");
        }

        public override bool CanBeCancelled() => true;

        public override bool CanBeDeclined() => true;

        protected override string GetHashString()
        {
            return $"SSPXStation{TargetBody}";
        }

        protected override string GetTitle() => "Build a new space station in orbit of }";

        protected override string GetDescription()
        {
            return base.GetDescription();
        }

        protected override string GetSynopsys()
        {
            return base.GetSynopsys();
        }

        protected override string MessageCompleted()
        {
            return base.MessageCompleted();
        }

        protected override void OnRegister()
        {
            base.OnRegister();
        }

        protected override void OnUnregister()
        {
            base.OnUnregister();
        }

        protected override void OnLoad(ConfigNode node)
        {
            base.OnLoad(node);
        }

        protected override void OnSave(ConfigNode node)
        {
            base.OnSave(node);
        }

        public override bool MeetRequirements()
        {
            return TargetBody != null;
        }
    }
}
