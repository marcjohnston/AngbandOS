// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GrendelMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperOSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "An ogre renowned for acts of surpassing cruelty.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Grendel";
    public override bool Giant => true;
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmunePoison => true;
    public override int LevelFound => 27;
    public override bool Male => true;
    public override int Mexp => 1500;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Grendel";
    public override bool Unique => true;
}
