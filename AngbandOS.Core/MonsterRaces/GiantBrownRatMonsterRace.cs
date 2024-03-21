// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantBrownRatMonsterRace : MonsterRace
{
    protected GiantBrownRatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerRSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Giant brown rat";

    public override bool Animal => true;
    public override int ArmorClass => 7;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(PoisonAttackEffect), 1, 3),
    };
    public override string Description => "It is a very vicious rodent.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant brown rat";
    public override int Hdice => 2;
    public override int Hside => 2;
    public override int LevelFound => 4;
    public override int Mexp => 1;
    public override bool Multiply => true;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "   brown    ";
    public override string SplitName3 => "    rat     ";
}
