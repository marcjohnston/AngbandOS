namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class ConfuseMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool UsesConfusion => true;
        public override bool Annoys => true;

        public override string? VsPlayerBlindMessage => $"Someone mumbles, and you hear puzzling noises.";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} creates a mesmerising illusion.";
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} creates a mesmerising illusion in front of {target.Name}";

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            if (saveGame.Player.HasConfusionResistance)
            {
                saveGame.MsgPrint("You disbelieve the feeble spell.");
            }
            else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You disbelieve the feeble spell.");
            }
            else
            {
                saveGame.Player.TimedConfusion.SetTimer(saveGame.Player.TimedConfusion.TimeRemaining + Program.Rng.RandomLessThan(4) + 4);
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, new ConfSpellResistantDetection());
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            bool blind = saveGame.Player.TimedBlindness.TimeRemaining != 0;
            bool seeTarget = !blind && target.IsVisible;
            string targetName = target.Name;
            MonsterRace targetRace = target.Race;

            if (targetRace.ImmuneConfusion)
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} disbelieves the feeble spell.");
                }
            }
            else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} disbelieves the feeble spell.");
                }
            }
            else
            {
                if (seeTarget)
                {
                    saveGame.MsgPrint($"{targetName} seems confused.");
                }
                target.ConfusionLevel += 12 + Program.Rng.RandomLessThan(4);
            }
        }
    }
}
