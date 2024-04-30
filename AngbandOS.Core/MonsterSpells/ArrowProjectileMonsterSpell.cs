// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal abstract class ArrowProjectileMonsterSpell : BoltProjectileMonsterSpell
{
    protected ArrowProjectileMonsterSpell(Game game) : base(game) { }
    public override bool IsInnate => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    /// <summary>
    /// Returns a message that the monster is making some strange noise.
    /// </summary>
    /// <param name="monsterName"></param>
    /// <returns></returns>
    public override string? VsPlayerBlindMessage => $"You hear a strange noise.";
    protected override string ActionName => "fires an arrow";
    protected override Projectile Projectile(Game game) => game.SingletonRepository.Get<Projectile>(nameof(ArrowProjectile));
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ReflectSpellResistantDetection)) };
}
