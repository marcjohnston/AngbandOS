// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmeagolMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerHSymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    
    public override int ArmorClass => 12;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatGoldAttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He's been sneaking, and he wants his 'precious.'";
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Smeagol";
    public override int Hdice => 10;
    public override int Hside => 20;
    public override bool Invisible => true;
    public override int LevelFound => 3;
    public override bool Male => true;
    public override int Mexp => 16;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 5;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Smeagol";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
