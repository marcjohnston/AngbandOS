// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CaveTrollMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperTSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8)
    };
    public override bool BashDoor => true;
    public override string Description => "He is a vicious monster, feared for his ferocity.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Cave troll";
    public override bool Friends => true;
    public override int Hdice => 24;
    public override int Hside => 12;
    public override bool HurtByLight => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 33;
    public override bool Male => true;
    public override int Mexp => 350;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string? MultilineName => "Cave\ntroll";
    public override bool Troll => true;
}
