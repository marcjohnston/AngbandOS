// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class HealScriptMonsterSpell : ScriptMonsterSpell
{
    private HealScriptMonsterSpell(Game game) : base(game) { }
    public override bool IsIntelligent => true;
    public override bool Heals => true;

    public override string? VsPlayerActionMessage => "{0} concentrates on {1} wounds.";

    public override string? ExecuteOnPlayerScriptBindingKey => nameof(HealMonsterSpellOnPlayerScript);
    public override string? ExecuteOnMonsterScriptBindingKey => nameof(HealMonsterSpellOnMonsterScript);
}
