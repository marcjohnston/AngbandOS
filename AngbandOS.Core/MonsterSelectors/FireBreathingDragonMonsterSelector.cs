namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class FireBreathingDragonMonsterSelector : MonsterSelector
{
    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        return !rPtr.Unique && "Dd".Contains(rPtr.Character.ToString()) && rPtr.BreatheFire;
    }
}
