// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class Arrow1D6MonsterSpell : ArrowProjectileMonsterSpell
{
    private Arrow1D6MonsterSpell(Game game) : base(game) { }

    protected override string DamageRollExpression => "1d6";
    public override string? VsPlayerActionMessage => "{0} fires an arrow.";

    public override string? VsMonsterSeenMessage => "{0} fires an arrow at {3}";
}
