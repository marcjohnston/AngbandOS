// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FireGiantMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperPSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override int ArmorClass => 60;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.FireAttackEffect), 3, 7),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 7),
    };
    public override bool BashDoor => true;
    public override string Description => "A glowing fourteen foot tall giant. Flames drip from its red skin.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Fire giant";
    public override bool Giant => true;
    public override int Hdice => 20;
    public override int Hside => 8;
    public override bool ImmuneFire => true;
    public override int LevelFound => 16;
    public override bool Male => true;
    public override int Mexp => 54;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Fire\ngiant";
}
