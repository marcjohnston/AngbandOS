// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GoatOfMendesMonsterRace : MonsterRace
{
    protected GoatOfMendesMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ColdBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(SummonDemonMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerQSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "Goat of Mendes";

    public override int ArmorClass => 66;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(TerrifyAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(ButtAttack), nameof(HurtAttackEffect), 6, 6),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(Exp40AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(LoseConAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "It is a demonic creature from the lowest hell, vaguely resembling a large black he-goat.";
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Goat of Mendes";
    public override int Hdice => 18;
    public override int Hside => 111;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 50;
    public override int Mexp => 6666;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override int Sleep => 40;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "    Goat    ";
    public override string SplitName2 => "     of     ";
    public override string SplitName3 => "   Mendes   ";
}
