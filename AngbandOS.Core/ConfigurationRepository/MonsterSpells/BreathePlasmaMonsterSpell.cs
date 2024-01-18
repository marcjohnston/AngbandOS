// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BreathePlasmaMonsterSpell : BreatheProjectileMonsterSpell
{
    private BreathePlasmaMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    protected override string ElementName => "plasma";
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get(nameof(PlasmaProjectile));
    protected override int Damage(Monster monster) => monster.Health / 6 > 150 ? 150 : monster.Health / 6;
}
