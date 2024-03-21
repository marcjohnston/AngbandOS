// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantRedAntMonsterRace : MonsterRace
{
    protected GiantRedAntMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerASymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string Name => "Giant red ant";

    public override bool Animal => true;
    public override int ArmorClass => 34;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 4),
        new MonsterAttackDefinition(nameof(StingAttack), nameof(LoseStrAttackEffect), 1, 4),
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
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "    red     ";
    public override string SplitName3 => "    ant     ";
    public override bool WeirdMind => true;
}
