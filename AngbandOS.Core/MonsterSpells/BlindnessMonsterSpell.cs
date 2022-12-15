using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class BlindnessMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool UsesBlindness => true;
        public override bool Annoys => true;

        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} casts a spell, burning your eyes!";

        public override string? VsMonsterSeenMessage(Monster monster, Monster target)
        {
            string targetName = target.Name;
            string it = targetName != "it" ? "s" : "'s";
            return $"{monster.Name} casts a spell, burning {targetName}{it} eyes.";
        }

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {

            if (saveGame.Player.HasBlindnessResistance)
            {
                saveGame.MsgPrint("You are unaffected!");
            }
            else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You resist the effects!");
            }
            else
            {
                saveGame.Player.SetTimedBlindness(12 + Program.Rng.RandomLessThan(4));
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsBlind);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            string targetName = target.Name;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            MonsterRace targetRace = target.Race;

            if (targetRace.ImmuneConfusion)
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
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} is blinded!");
                }
                target.ConfusionLevel += 12 + Program.Rng.RandomLessThan(4);
            }
        }
    }
}
