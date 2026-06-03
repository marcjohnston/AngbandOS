// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ScareScriptMonsterSpell : ScriptMonsterSpell
{
    private ScareScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool UsesFear => true;
    public override bool IsAttack => true;
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone mumbles, and you hear scary noises.";

    public override string? VsPlayerActionMessage => "{0} casts a fearful illusion.";

    public override string? VsMonsterSeenMessage => "{0} casts a fearful illusion at {3}";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(ScareMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(ScareMonsterSpellOnMonsterScript);
}
