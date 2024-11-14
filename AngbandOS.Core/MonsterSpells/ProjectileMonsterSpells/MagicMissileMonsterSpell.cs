// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class MagicMissileMonsterSpell : ProjectileMonsterSpell
{
    private MagicMissileMonsterSpell(Game game) : base(game) { }
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;

    public override string? VsMonsterSeenMessage => "{0} casts a magic missile at {3}";
    public override string? VsPlayerActionMessage => "{0} casts a magic missile.";

    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DiceRoll(2, 6) + (monsterLevel / 3);
    }

    protected override string ProjectileKey => nameof(MissileProjectile);

    protected override string[] SmartLearnSpellResistantDetectionKeys => new string[] { nameof(ReflectSpellResistantDetection) };
}
