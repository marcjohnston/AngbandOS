namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class ForgetMonsterSpell : MonsterSpell
    {
        public override bool Annoys => true;

        public override string? VsPlayerBlindMessage => $"Someone tries to blank your mind.";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} tries to blank your mind.";
        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            string monsterName = monster.Name;

            if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You resist the effects!");
            }
            else if (saveGame.LoseAllInfo())
            {
                saveGame.MsgPrint("Your memories fade away.");
            }
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
        }
    }
}
