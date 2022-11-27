namespace AngbandOS.Core.MonsterSelectors
{
    internal abstract class MonsterSelector
    {
        public abstract bool Matches(SaveGame saveGame, int rIdx);
    }
}
