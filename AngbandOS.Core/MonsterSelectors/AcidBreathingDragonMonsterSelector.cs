using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AcidBreathingDragonMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return !rPtr.Unique && "Dd".Contains(rPtr.Character.ToString()) && rPtr.BreatheAcid;
        }
    }
}
