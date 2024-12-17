using System.Collections.Generic;
using System.Linq;
using ContractConfigurator;

namespace SpaceLabs
{
    public class StationCoreRequirement : ContractRequirement
    {
        private List<AvailablePart> parts = PartLoader.LoadedPartsList
            .Where(part => (part.name.Contains("sspx-core") 
                            || part.title.Contains("Station Core") 
                            || part.name is "crewCabin") 
                            && part.partPrefab.CrewCapacity > 0)
            .ToList();

        public override void OnLoad(ConfigNode configNode) { }

        public override void OnSave(ConfigNode configNode) { }

        protected override string RequirementText() => "Must have unlocked a station core or non-command crewed part.";

        public override bool RequirementMet(ConfiguredContract contract)
        {   
            var unlockedparts = parts.Where(part => ResearchAndDevelopment.Instance.GetTechState(part.TechRequired) != null);
            return unlockedparts.Count() > 0;
        }
    }
}