// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class BlindnessScriptMonsterSpell : ScriptMonsterSpell
{
    private BlindnessScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesBlindness => true;
    public override bool Annoys => true;

    public override string? VsPlayerActionMessage => "{0} casts a spell, burning your eyes!";

    public override string? VsMonsterSeenMessage => "{0} casts a spell, burning {4} eyes.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(BlindnessMonsterSpellOnPlayerScript);

    public override string? ExecuteOnMonsterScriptBindingKey => nameof(BlindnessMonsterSpellOnMonsterScript);
}
