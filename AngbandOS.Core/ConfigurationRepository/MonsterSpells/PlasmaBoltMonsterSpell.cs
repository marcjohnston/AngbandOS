﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class PlasmaBoltMonsterSpell : BoltProjectileMonsterSpell
{
    private PlasmaBoltMonsterSpell(SaveGame saveGame) : base(saveGame) { }
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts a plasma bolt";
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return 10 + SaveGame.Rng.DiceRoll(8, 7) + monsterLevel;
    }
    protected override Projectile Projectile(SaveGame saveGame) => saveGame.SingletonRepository.Projectiles.Get<PlasmaProjectile>();
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { SaveGame.SingletonRepository.SpellResistantDetections.Get<ReflectSpellResistantDetection>() };
}