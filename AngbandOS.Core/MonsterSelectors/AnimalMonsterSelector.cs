namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class AnimalMonsterSelector : MonsterSelector
    {
        /// <summary>
        /// Returns true, if a monster is not unique and is an animal.
        /// </summary>
        /// <param name="rIdx"></param>
        /// <returns></returns>
        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            return rPtr.Animal && !rPtr.Unique;
        }
    }
}
