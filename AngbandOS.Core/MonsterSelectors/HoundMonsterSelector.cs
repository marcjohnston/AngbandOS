namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class HoundMonsterSelector : MonsterSelector
{
    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        return (rPtr.Character == 'C' || rPtr.Character == 'Z') && !rPtr.Unique;
    }
}
