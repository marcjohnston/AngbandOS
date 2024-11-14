// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class IceBoltMonsterSpell : ProjectileMonsterSpell
{
    private IceBoltMonsterSpell(Game game) : base(game) { }
    public override bool UsesCold => true;
    public override bool CanBeReflected => true;
    public override bool IsAttack => true;
    protected override string ActionName => "casts an ice bolt";
    protected override int Damage(Monster monster)
    {
        int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
        return Game.DiceRoll(6, 6) + monsterLevel;
    }
    protected override string ProjectileKey => nameof(IceProjectile);
    public override SpellResistantDetection[] SmartLearn => new SpellResistantDetection[] { Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ColdSpellResistantDetection)), Game.SingletonRepository.Get<SpellResistantDetection>(nameof(ReflectSpellResistantDetection)) };
}
