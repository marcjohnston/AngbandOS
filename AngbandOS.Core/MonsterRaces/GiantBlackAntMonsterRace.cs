// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantBlackAntMonsterRace : MonsterRace
{
    protected GiantBlackAntMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerASymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Giant black ant";

    public override bool Animal => true;
    public override int ArmorClass => 20;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about three feet long.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant black ant";
    public override int Hdice => 3;
    public override int Hside => 6;
    public override int LevelFound => 2;
    public override int Mexp => 8;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "   black    ";
    public override string SplitName3 => "    ant     ";
    public override bool WeirdMind => true;
}
