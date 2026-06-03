// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ForgetScriptMonsterSpell : ScriptMonsterSpell
{
    private ForgetScriptMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone tries to blank your mind.";
    public override string? VsPlayerActionMessage => "{0} tries to blank your mind.";
    public override string? ExecuteOnPlayerScriptBindingKey => nameof(ForgetMonsterSpellOnPlayerScript);
}
