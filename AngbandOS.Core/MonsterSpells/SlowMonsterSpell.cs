using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class SlowMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool RestrictsFreeAction => true;
        public override bool Annoys => true;

        public override string? VsPlayerBlindMessage => $"Someone drains power from your muscles!";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} drains power from your muscles!";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target)
        {
            string monsterName = target.Name;
            string targetName = target.Name;
            string it = (targetName == "it" ? "s" : "'s");
            return $"{monsterName} drains power from {targetName}{it} muscles.";
        }

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            string monsterName = monster.Name;
  
            if (saveGame.Player.HasFreeAction)
            {
                saveGame.MsgPrint("You are unaffected!");
            }
            else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You resist the effects!");
            }
            else
            {
                saveGame.Player.SetTimedSlow(saveGame.Player.TimedSlow + Program.Rng.RandomLessThan(4) + 4);
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsFree);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            MonsterRace targetRace = target.Race;
            string targetName = target.Name;

            if (targetRace.Unique)
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} is unaffected.");
                }
            }
            else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} is unaffected.");
                }
            }
            else
            {
                target.Speed -= 10;
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} starts moving slower.");
                }
            }
        }
    }
}
