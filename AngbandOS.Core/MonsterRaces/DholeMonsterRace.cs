// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DholeMonsterRace : MonsterRace
{
    protected DholeMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheAcidMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperASymbol);
    public override ColorEnum Color => ColorEnum.Beige;
    public override string Name => "Dhole";

    public override bool Animal => true;
    public override int ArmorClass => 64;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(SpitAttack), nameof(AcidAttackEffect), 1, 8),
        new MonsterAttackDefinition(nameof(EngulfAttack), nameof(AcidAttackEffect), 2, 8),
        new MonsterAttackDefinition(nameof(CrushAttack), nameof(HurtAttackEffect), 4, 8),
    };
    public override bool Cthuloid => true;
    public override string Description => "A gigantic worm dripping with acid.";
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Dhole";
    public override int Hdice => 65;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override bool KillWall => true;
    public override int LevelFound => 29;
    public override int Mexp => 500;
    public override int NoticeRange => 14;
    public override int Rarity => 4;
    public override int Sleep => 25;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Dhole    ";
}
