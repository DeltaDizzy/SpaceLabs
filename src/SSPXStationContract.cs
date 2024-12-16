using System.Linq;
using Contracts;
using Contracts.Parameters;

namespace SpaceLabs 
{
    public class SSPXStationContract : Contract
    {
        private float reward;
        private CelestialBody TargetBody {
            get {
                // next body kerbin that has been orbited
                //var orbitedbodies = ProgressTracking.Instance.celestialBodyNodes.Where(tree => tree.orbit.IsComplete)
                return FlightGlobals.Bodies.Find(b => b.name is "Kerbin");
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

        public override bool CanBeCancelled()
        {
            return base.CanBeCancelled();
        }

        public override bool CanBeDeclined()
        {
            return base.CanBeDeclined();
        }

        protected override string GetHashString()
        {
            return base.GetHashString();
        }

        protected override string GetTitle() => "Build a new space station in orbit of Kerbin";

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
            return base.MeetRequirements();
        }
    }
}
