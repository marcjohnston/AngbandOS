// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class TeleportAwayScriptMonsterSpell : ScriptMonsterSpell
{
    private TeleportAwayScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;

    public override bool ProvidesEscape => true;

    public override string? VsPlayerBlindMessage => "Someone teleports you away.";
    public override string? VsPlayerActionMessage => "{0} teleports you away.";
    public override string? VsMonsterSeenMessage => "{0} teleports {3} away.";
    public override string? VsMonsterUnseenMessage => null;

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(TeleportAwayMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(TeleportAwayMonsterSpellOnMonsterScript);
}
