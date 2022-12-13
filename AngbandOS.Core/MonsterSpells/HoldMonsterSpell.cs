using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class HoldMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool RestrictsFreeAction => true;
        public override bool Annoys => true;

        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} stares deep into your eyes!";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} stares intently at {target.Name}";

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
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
                saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4);
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsFree);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            string targetName = target.Name;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            MonsterRace targetRace = target.Race;

            if (targetRace.Unique || targetRace.ImmuneStun)
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
                target.StunLevel += Program.Rng.DieRoll(4) + 4;
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} is paralyzed!");
                }
            }
        }
    }
}
