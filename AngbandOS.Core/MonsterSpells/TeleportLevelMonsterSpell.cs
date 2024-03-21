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
    private TeleportLevelMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesNexus => true;
    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => $"Someone mumbles strangely.";
    public override string? VsPlayerActionMessage(Monster monster) => $"{monster.Name} gestures at your feet.";

    public override void ExecuteOnPlayer(Game game, Monster monster)
    {

        if (game.HasNexusResistance)
        {
            game.MsgPrint("You are unaffected!");
        }
        else if (Game.RandomLessThan(100) < game.SkillSavingThrow)
        {
            game.MsgPrint("You resist the effects!");
        }
        else
        {
            Game.RunScript(nameof(TeleportLevelScript));
        }
        game.UpdateSmartLearn(monster, Game.SingletonRepository.SpellResistantDetections.Get(nameof(NexusSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Game game, Monster monster, Monster target)
    {
    }
}
