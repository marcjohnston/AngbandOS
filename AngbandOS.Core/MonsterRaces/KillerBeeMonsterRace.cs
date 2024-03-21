// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KillerBeeMonsterRace : MonsterRace
{
    protected KillerBeeMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(UpperISymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "Killer bee";

    public override bool Animal => true;
    public override int ArmorClass => 34;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(StingAttack), nameof(PoisonAttackEffect), 1, 4),
        new MonsterAttackDefinition(nameof(StingAttack), nameof(LoseStrAttackEffect), 1, 4),
    };
    public override string Description => "It is poisonous and aggressive.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Killer bee";
    public override bool Friends => true;
    public override int Hdice => 2;
    public override int Hside => 4;
    public override int LevelFound => 9;
    public override int Mexp => 22;
    public override int NoticeRange => 12;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Killer   ";
    public override string SplitName3 => "    bee     ";
    public override bool WeirdMind => true;
}
