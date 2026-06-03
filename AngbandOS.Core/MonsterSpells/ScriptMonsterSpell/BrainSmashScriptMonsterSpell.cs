// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class BrainSmashScriptMonsterSpell : ScriptMonsterSpell
{
    private BrainSmashScriptMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "You feel something focusing on your mind.";

    public override string? VsPlayerActionMessage => "{0} looks deep into your eyes.";

    public override string? VsMonsterUnseenMessage => null;

    public override string? VsMonsterSeenMessage => "{0} gazes intently at {3}";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(BrainSmashMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(BrainSmashMonsterSpellOnMonsterScript);
}
