﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BreatheChaosMonsterSpell : BreatheProjectileMonsterSpell
{
    private BreatheChaosMonsterSpell(Game game) : base(game) { }
    public override bool UsesChaos => true;
    protected override string ElementName => "chaos";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Get<Projectile>(nameof(ChaosProjectile));
    protected override int Damage(Monster monster) => monster.Health / 6 > 600 ? 600 : monster.Health / 6;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ChaosSpellResistantDetection)) };
}
