namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AvatarMonsterSelector : MonsterSelector
    {
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Name == "Avatar of Nyarlathotep" && !rPtr.Unique;
        }
    }
}
