// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ConfuseMonsterSpell : MonsterSpell
{
    private ConfuseMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool IsIntelligent => true;
    public override bool UsesConfusion => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => $"Someone mumbles, and you hear puzzling noises.";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} creates a mesmerising illusion.";
    public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} creates a mesmerising illusion in front of {target.Name}";

    public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
    {
        if (saveGame.HasConfusionResistance)
        {
            saveGame.MsgPrint("You disbelieve the feeble spell.");
        }
        else if (Program.Rng.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You disbelieve the feeble spell.");
        }
        else
        {
            saveGame.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(4) + 4);
        }
        saveGame.UpdateSmartLearn(monster, new ConfSpellResistantDetection());
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
        int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        bool blind = saveGame.TimedBlindness.TurnsRemaining != 0;
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
