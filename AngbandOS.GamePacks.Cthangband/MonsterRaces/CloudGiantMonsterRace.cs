// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CloudGiantMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperPSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override int ArmorClass => 60;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is a twenty foot tall giant wreathed in clouds.";
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cloud giant";
    public override bool Giant => true;
    public override int Hdice => 24;
    public override int Hside => 10;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 20;
    public override bool Male => true;
    public override int Mexp => 125;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Cloud\ngiant";
    public override bool TakeItem => true;
}
