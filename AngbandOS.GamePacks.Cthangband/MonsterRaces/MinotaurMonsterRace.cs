// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MinotaurMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperHSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override int ArmorClass => 25;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ButtAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(ButtAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 4, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a cross between a human and a bull.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Minotaur";
    public override int Hdice => 100;
    public override int Hside => 10;
    public override int LevelFound => 40;
    public override int Mexp => 2100;
    public override int NoticeRange => 13;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string? MultilineName => "Minotaur";
}
