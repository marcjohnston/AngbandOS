// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BanditMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 24;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 4),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatGoldAttackEffect), 0, 0),
    };
    public override bool BashDoor => true;
    public override string Description => "He is after your cash!";
    public override bool Drop_1D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Bandit";
    public override int Hdice => 8;
    public override int Hside => 8;
    public override int LevelFound => 8;
    public override bool Male => true;
    public override int Mexp => 26;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Bandit";
    public override bool TakeItem => true;
}
