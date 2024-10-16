﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class BreatheLightMonsterSpell : BreatheProjectileMonsterSpell
{
    private BreatheLightMonsterSpell(Game game) : base(game) { }
    public override bool UsesLight => true;
    protected override string ElementName => "light";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Get<Projectile>(nameof(LightProjectile));
    protected override int Damage(Monster monster) => monster.Health / 6 > 400 ? 400 : monster.Health / 6;
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(LightSpellResistantDetection)) };
}
