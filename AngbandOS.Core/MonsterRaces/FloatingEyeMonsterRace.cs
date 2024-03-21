// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FloatingEyeMonsterRace : MonsterRace
{
    protected FloatingEyeMonsterRace(Game game) : base(game) { }

    protected override string SymbolName => nameof(LowerESymbol);
    public override string Name => "Floating eye";

    public override int ArmorClass => 6;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(ParalyzeAttackEffect), 0, 0),
    };
    public override string Description => "A disembodied eye, floating a few feet above the ground.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Floating eye";
    public override int Hdice => 3;
    public override int Hside => 6;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override bool NeverMove => true;
    public override int NoticeRange => 2;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Floating  ";
    public override string SplitName3 => "    eye     ";
}
