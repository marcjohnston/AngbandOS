namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class GooMonsterSelector : MonsterSelector
{
    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        return rPtr.GreatOldOne;
    }
}
