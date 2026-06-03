// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class SlowScriptMonsterSpell : ScriptMonsterSpell
{
    private SlowScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool RestrictsFreeAction => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone drains power from your muscles!";
    public override string? VsPlayerActionMessage => "{0} drains power from your muscles!";
    public override string? VsMonsterSeenMessage => "{0} drains power from {4} muscles.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(SlowMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(SlowMonsterSpellOnMonsterScript);
}
