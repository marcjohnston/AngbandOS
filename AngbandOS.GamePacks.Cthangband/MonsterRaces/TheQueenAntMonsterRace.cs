// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheQueenAntMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AntSummonMonsterSpell)
    };

    public override string SymbolName => nameof(LowerASymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    
    public override bool Animal => true;
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 8)
    };
    public override bool BashDoor => true;
    public override string Description => "She's upset because you hurt her children.";
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "The Queen Ant";
    public override bool Good => true;
    public override int Hdice => 15;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 37;
    public override int Mexp => 1000;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "The\nQueen\nAnt";
    public override bool Unique => true;
    public override bool WeirdMind => true;
}
