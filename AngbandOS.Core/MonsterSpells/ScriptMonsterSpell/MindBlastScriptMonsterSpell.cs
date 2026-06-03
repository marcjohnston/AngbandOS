// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class MindBlastScriptMonsterSpell : ScriptMonsterSpell
{
    private MindBlastScriptMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You feel something focusing on your mind.";

    public override string? VsPlayerActionMessage => "{0} gazes deep into your eyes.";

    /// <summary>
    /// Returns null, because a blind player will not be aware this action is taking place.
    /// </summary>
    public override string? VsMonsterUnseenMessage => null;

    public override string? VsMonsterSeenMessage => $"{0} gazes intently at {3}";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(MindBlastMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(MindBlastMonsterSpellOnMonsterScript);
}