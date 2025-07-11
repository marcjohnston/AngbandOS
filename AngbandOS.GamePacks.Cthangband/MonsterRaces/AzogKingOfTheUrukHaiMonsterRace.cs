// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AzogKingOfTheUrukHaiMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerOSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 5, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "He is also known as the King of Khazad-dum. His ego is renowned to be bigger than his head.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Azog, King of the Uruk-Hai";
    public override int Hdice => 90;
    public override int Hside => 10;
    public override bool ImmunePoison => true;
    public override int LevelFound => 23;
    public override bool Male => true;
    public override int Mexp => 1111;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Orc => true;
    public override int Rarity => 5;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Azog";
    public override bool Unique => true;
}
