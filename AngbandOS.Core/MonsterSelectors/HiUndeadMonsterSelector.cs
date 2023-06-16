namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class HiUndeadMonsterSelector : MonsterSelector
{
    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        return rPtr.Character == 'L' || rPtr.Character == 'V' || rPtr.Character == 'W';
    }
}
