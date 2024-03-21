// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BreatheDisintegrationMonsterSpell : BreatheProjectileMonsterSpell
{
    private BreatheDisintegrationMonsterSpell(Game game) : base(game) { }
    protected override string ElementName => "disintegration";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile));
    protected override int Damage(Monster monster) => monster.Health / 3 > 300 ? 300 : monster.Health / 3;
}
