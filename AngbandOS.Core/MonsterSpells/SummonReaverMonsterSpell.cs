namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SummonReaverMonsterSpell : SummonMonsterSpell
    {
        protected override string SummonName(Monster monster) => "Black Reavers";

        protected override int MaximumSummonCount(SaveGame saveGame) => (saveGame.Difficulty / 50) + Program.Rng.DieRoll(6);

        protected override int SummonLevel(Monster monster) => 100;

        /// <summary>
        /// Returns null, because the Execute methods are overridden because Reavers can only be summoned via the SummonReaver method.
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        protected override MonsterSelector? MonsterSelector(Monster monster) => new ReaverMonsterSelector();
    }
}
