// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class AcidBoltMonsterSpell : BoltProjectileMonsterSpell
{
    private AcidBoltMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool UsesAcid => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a acid bolt";
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Program.Rng.DiceRoll(7, 8) + (monsterLevel / 3);
    }
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<AcidProjectile>();
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { new AcidSpellResistantDetection(), new ReflectSpellResistantDetection() };
}
