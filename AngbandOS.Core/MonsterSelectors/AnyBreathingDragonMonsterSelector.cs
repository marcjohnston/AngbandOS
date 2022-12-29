namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AnyBreathingDragonMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return !rPtr.Unique && "Dd".Contains(rPtr.Character.ToString()) && (rPtr.BreatheAcid || rPtr.BreatheLightning || rPtr.BreatheFire || rPtr.BreatheCold || rPtr.BreathePoison);
        }
    }
}
