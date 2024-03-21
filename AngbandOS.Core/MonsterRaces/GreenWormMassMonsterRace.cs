// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreenWormMassMonsterRace : MonsterRace
{
    protected GreenWormMassMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerWSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Green worm mass";

    public override bool Animal => true;
    public override int ArmorClass => 3;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrawlAttack), nameof(AcidAttackEffect), 1, 3),
    };
    public override string Description => "It is a large slimy mass of worms.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Green worm mass";
    public override int Hdice => 6;
    public override int Hside => 4;
    public override bool HurtByLight => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 2;
    public override int Mexp => 3;
    public override bool Multiply => true;
    public override int NoticeRange => 7;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "   Green    ";
    public override string SplitName2 => "    worm    ";
    public override string SplitName3 => "    mass    ";
    public override bool Stupid => true;
    public override bool WeirdMind => true;
}
