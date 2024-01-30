// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RedNagaMonsterRace : MonsterRace
{
    protected RedNagaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(LowerNSymbol);
    public override ColorEnum Color => ColorEnum.BrightRed;
    public override string Name => "Red naga";

    public override int ArmorClass => 40;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(HurtAttackEffect), 1, 10),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(LoseStrAttackEffect), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "A large red snake with a woman's torso.";
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Red naga";
    public override int Hdice => 11;
    public override int Hside => 8;
    public override int LevelFound => 7;
    public override int Mexp => 40;
    public override int NoticeRange => 20;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 120;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Red     ";
    public override string SplitName3 => "    naga    ";
    public override bool TakeItem => true;
}
