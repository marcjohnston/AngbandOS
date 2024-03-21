// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MirkwoodSpiderMonsterRace : MonsterRace
{
    protected MirkwoodSpiderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string SymbolName => nameof(UpperSSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Mirkwood spider";

    public override bool Animal => true;
    public override int ArmorClass => 25;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(HurtAttackEffect), 1, 8),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(PoisonAttackEffect), 1, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(PoisonAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A strong and powerful spider from Mirkwood forest. Cunning and evil, it seeks to taste your juicy insides.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Mirkwood spider";
    public override bool Friends => true;
    public override int Hdice => 9;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 15;
    public override int Mexp => 25;
    public override int NoticeRange => 15;
    public override int Rarity => 2;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Mirkwood  ";
    public override string SplitName3 => "   spider   ";
    public override bool WeirdMind => true;
}
