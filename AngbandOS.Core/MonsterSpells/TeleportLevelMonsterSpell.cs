using AngbandOS.Core.SpellResistantDetections;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class TeleportLevelMonsterSpell : MonsterSpell
    {
        public override bool IsIntelligent => true;
        public override bool UsesNexus => true;
        public override bool ProvidesEscape => true;

        public override string? VsPlayerBlindMessage => $"Someone mumbles strangely.";
        public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} gestures at your feet.";

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {

            if (saveGame.Player.HasNexusResistance)
            {
                saveGame.MsgPrint("You are unaffected!");
            }
            else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
            {
                saveGame.MsgPrint("You resist the effects!");
            }
            else
            {
                saveGame.TeleportPlayerLevel();
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, new NexusSpellResistantDetection());
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
        }
    }
}
