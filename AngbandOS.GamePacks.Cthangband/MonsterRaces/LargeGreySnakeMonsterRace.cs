// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeGreySnakeMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperJSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override bool Animal => true;
    public override int ArmorClass => 41;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 5),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 8),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about ten feet long.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Large grey snake";
    public override int Hdice => 6;
    public override int Hside => 8;
    public override int LevelFound => 4;
    public override int Mexp => 14;
    public override int NoticeRange => 6;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 100;
    public override string? MultilineName => "Large\ngrey\nsnake";
}
