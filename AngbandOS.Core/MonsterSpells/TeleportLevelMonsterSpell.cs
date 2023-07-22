// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

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

        if (saveGame.HasNexusResistance)
        {
            saveGame.MsgPrint("You are unaffected!");
        }
        else if (Program.Rng.RandomLessThan(100) < saveGame.SkillSavingThrow)
        {
            saveGame.MsgPrint("You resist the effects!");
        }
        else
        {
            saveGame.TeleportPlayerLevel();
        }
        saveGame.Level.UpdateSmartLearn(monster, new NexusSpellResistantDetection());
    }

    public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
    {
    }
}
