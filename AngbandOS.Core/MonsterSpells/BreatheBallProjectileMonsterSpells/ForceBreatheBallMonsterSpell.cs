// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class ForceBreatheBallMonsterSpell : BreatheBallProjectileMonsterSpell
{
    private ForceBreatheBallMonsterSpell(Game game) : base(game) { }
    protected override string ActionName => "breathes force";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Get<Projectile>(nameof(ForceProjectile));
    protected override int MonsterHealthDamageDivisor => 6;
    protected override int MaxDamage => 200;
}
