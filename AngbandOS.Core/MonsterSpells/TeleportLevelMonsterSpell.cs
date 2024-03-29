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

    public override void ExecuteOnPlayer(Monster monster)
    {

        if (Game.HasNexusResistance)
        {
            Game.MsgPrint("You are unaffected!");
        }
        else if (base.Game.RandomLessThan(100) < Game.SkillSavingThrow)
        {
            Game.MsgPrint("You resist the effects!");
        }
        else
        {
            base.Game.RunScript(nameof(Scripts.TeleportLevelScript));
        }
        Game.UpdateSmartLearn(monster, base.Game.SingletonRepository.SpellResistantDetections.Get(nameof(SpellResistantDetections.NexusSpellResistantDetection)));
    }

    public override void ExecuteOnMonster(Monster monster, Monster target) // TODO: Not implemented
    {
    }
}
