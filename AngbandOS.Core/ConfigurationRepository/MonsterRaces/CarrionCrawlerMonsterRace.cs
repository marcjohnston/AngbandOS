// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CarrionCrawlerMonsterRace : MonsterRace
{
    protected CarrionCrawlerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerCSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Carrion crawler";

    public override bool Animal => true;
    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(StingAttack), nameof(ParalyzeAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(StingAttack), nameof(ParalyzeAttackEffect), 2, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A hideous centipede covered in slime and with glowing tentacles around its head.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Carrion crawler";
    public override bool Friends => true;
    public override int Hdice => 20;
    public override int Hside => 12;
    public override bool ImmunePoison => true;
    public override int LevelFound => 34;
    public override int Mexp => 100;
    public override int NoticeRange => 15;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Carrion   ";
    public override string SplitName3 => "  crawler   ";
    public override bool WeirdMind => true;
}
