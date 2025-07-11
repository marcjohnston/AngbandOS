// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RobinHoodTheOutlawMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.Arrow3D6MonsterSpell),
        nameof(MonsterSpellsEnum.CreateTrapsMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell)
    };

    public override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.BrightChartreuse;
    
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatGoldAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.EatItemAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "The legendary archer steals from the rich (you qualify). ";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Robin Hood, the Outlaw";
    public override int Hdice => 14;
    public override int Hside => 12;
    public override int LevelFound => 8;
    public override bool Male => true;
    public override int Mexp => 150;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Robin\nHood";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
