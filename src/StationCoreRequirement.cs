using System.Collections.Generic;
using System.Linq;
using ContractConfigurator;
using UnityEngine;

namespace SpaceLabs
{
    public class StationCoreRequirement : ContractRequirement
    {
        private List<AvailablePart> parts = PartLoader.LoadedPartsList
            .Where(part => (part.name.Contains("sspx-core") || part.title.Contains("Station Core") 
                            || part.name is "crewCabin") 
                            && part.partPrefab.CrewCapacity > 0)
            .ToList();

        public override void OnLoad(ConfigNode configNode) { }

        public override void OnSave(ConfigNode configNode) { }

        protected override string RequirementText() => "Must have unlocked a station core or non-command crewed part.";

        public override bool RequirementMet(ConfiguredContract contract)
        {   
            //ResearchAndDevelopment rnd = ResearchAndDevelopment.Instance;
            //Debug.Log($"[SpaceLabs]: instance is {rnd}");
            //rnd.
            //ProtoTechNode node = rnd.GetTechState("advExploration");
            //Debug.Log($"[SpaceLabs]: node is {node}");
            //RDTech.State state = node.state;
            //Debug.Log($"[SpaceLabs]: state is {state}");
            var unlockedparts = parts.Where(part => ResearchAndDevelopment.Instance.GetTechState(part.TechRequired) != null);
            //Debug.Log("[SpaceLabs]: valid parts:");
            //foreach (AvailablePart part in parts)
            //{
            //    Debug.Log($"[SpaceLabs]: {part.name} / {part.title}");
            //}
            //Debug.Log("[SpaceLabs]: ========================");
            //Debug.Log("[SpaceLabs]: unlocked parts:");
            //foreach (AvailablePart part in unlockedparts)
            //{
            //    Debug.Log($"[SpaceLabs]: {part.name} / {part.title}");
            //}
            
            return unlockedparts.Count() > 0;
        }
    }
}