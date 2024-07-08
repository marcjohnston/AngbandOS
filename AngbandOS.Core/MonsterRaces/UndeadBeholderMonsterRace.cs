// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class UndeadBeholderMonsterRace : MonsterRace
{
    protected UndeadBeholderMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerESymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 100;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(Exp40AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(ParalyzeAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(LoseIntAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(DrainStaffChargesAttackEffect), 2, 6),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(DrainWandChargesAttackEffect), 2, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A disembodied eye, floating in the air. Black nether storms rage around its bloodshot pupil and light seems to bend as it sucks its power from the very air around it. Your soul chills as it drains your vitality for its evil enchantments.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Undead beholder";
    public override int Hdice => 27;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 42;
    public override int Mexp => 4000;
    public override int NoticeRange => 30;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Undead\nbeholder";
    public override bool Undead => true;
}
