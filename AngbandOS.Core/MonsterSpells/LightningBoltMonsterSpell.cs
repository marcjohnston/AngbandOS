// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class LightningBoltMonsterSpell : BoltProjectileMonsterSpell
{
    private LightningBoltMonsterSpell(Game game) : base(game) { }
    public override bool UsesLightning => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a lightning bolt";
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DiceRoll(4, 8) + (monsterLevel / 3);
    }
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Projectiles.Get(nameof(ElecProjectile));
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.SpellResistantDetections.Get(nameof(ElecSpellResistantDetection)), Game.SingletonRepository.SpellResistantDetections.Get(nameof(ReflectSpellResistantDetection)) };
}
