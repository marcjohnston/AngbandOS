﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class FireBoltMonsterSpell : ProjectileMonsterSpell
{
    private FireBoltMonsterSpell(Game game) : base(game) { }
    public override bool UsesFire => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    public override string? VsMonsterSeenMessage => "{0} casts a fire bolt at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a fire bolt.";
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DiceRoll(9, 8) + (monsterLevel / 3);
    }
    protected override string ProjectileKey => nameof(FireProjectile);
    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(FireSpellResistantDetection), nameof(ReflectSpellResistantDetection) };
}
