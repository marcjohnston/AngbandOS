// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class DreadCurseScriptMonsterSpell : ScriptMonsterSpell
{
    private DreadCurseScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsAttack => true;
    public override string? VsPlayerBlindMessage => "You hear someone invoke the Dread Curse of Azathoth!";
    public override string? VsPlayerActionMessage => "{0} invokes the Dread Curse of Azathoth!";
    public override string? VsMonsterSeenMessage => "{0} invokes the Dread Curse of Azathoth on {3}";
    public override string? ExecuteOnPlayerScriptBindingKey => nameof(DreadCurseMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(DreadCurseMonsterSpellOnMonsterScript);
}
