// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantRedAntMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerASymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    
    public override bool Animal => true;
    public override int ArmorClass => 34;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(StingAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is large and has venomous mandibles.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant red ant";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override int LevelFound => 9;
    public override int Mexp => 22;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 60;
    public override int Speed => 110;
    public override string? MultilineName => "Giant\nred\nant";
    public override bool WeirdMind => true;
}
