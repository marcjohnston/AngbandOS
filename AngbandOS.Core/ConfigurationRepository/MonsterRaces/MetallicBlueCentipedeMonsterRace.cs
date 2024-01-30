// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MetallicBlueCentipedeMonsterRace : MonsterRace
{
    protected MetallicBlueCentipedeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerCSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Metallic blue centipede";

    public override bool Animal => true;
    public override int ArmorClass => 6;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrawlAttack), nameof(HurtAttackEffect), 1, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about four feet long and carnivorous.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Metallic blue centipede";
    public override int Hdice => 4;
    public override int Hside => 5;
    public override int LevelFound => 3;
    public override int Mexp => 7;
    public override int NoticeRange => 6;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 15;
    public override int Speed => 120;
    public override string SplitName1 => "  Metallic  ";
    public override string SplitName2 => "    blue    ";
    public override string SplitName3 => " centipede  ";
    public override bool WeirdMind => true;
}
