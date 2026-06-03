// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ConfuseScriptMonsterSpell : ScriptMonsterSpell
{
    private ConfuseScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesConfusion => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone mumbles, and you hear puzzling noises.";
    public override string? VsPlayerActionMessage => "{0} creates a mesmerising illusion.";
    public override string? VsMonsterSeenMessage => "{0} creates a mesmerising illusion in front of {3}";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(ConfuseMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(ConfuseMonsterSpellOnMonsterScript);
}
