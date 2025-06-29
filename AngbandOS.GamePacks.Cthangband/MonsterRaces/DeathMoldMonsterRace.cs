// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DeathMoldMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerMSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 60;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 7, 7),
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 7, 7),
        (nameof(HitAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 7, 7),
        (nameof(HitAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 5, 5)
    };
    public override string Description => "It is the epitome of all that is evil, in a mold. Its lifeless form draws power from sucking the souls of those that approach it, a nimbus of pure evil surrounds it. Luckily for you, it can't move.";
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Death mold";
    public override int Hdice => 100;
    public override int Hside => 20;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 47;
    public override int Mexp => 1000;
    public override bool NeverMove => true;
    public override int NoticeRange => 200;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 140;
    public override string? MultilineName => "Death\nmold";
}
