// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class TeleportLevelScriptMonsterSpell : ScriptMonsterSpell
{
    private TeleportLevelScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesNexus => true;
    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => "Someone mumbles strangely.";
    public override string? VsPlayerActionMessage => "{0} gestures at your feet.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(TeleportLevelMonsterSpellOnPlayerScript);
}
