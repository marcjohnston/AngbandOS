namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class ShriekMonsterSpell : MonsterSpell
    {
        public override bool IsInnate => true;
        public override bool Annoys => true;

        public override string? VsPlayerBlindMessage => "You hear a shriek.";

        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} makes a high pitched shriek.";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} shrieks at {target.Name}.";


        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            saveGame.AggravateMonsters(monster);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            // No additional processing needed.  It only wakes the monster.
        }
    }
}
