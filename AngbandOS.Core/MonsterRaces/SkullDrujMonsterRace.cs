// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SkullDrujMonsterRace : MonsterRace
{
    protected SkullDrujMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(SummonUndeadMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerSSymbol);
    public override ColorEnum Color => ColorEnum.BrightGrey;
    
    public override int ArmorClass => 120;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(Exp80AttackEffect), 4, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(ParalyzeAttackEffect), 4, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(LoseIntAttackEffect), 4, 4),
        new MonsterAttackDefinition(nameof(BiteAttack), nameof(LoseWisAttackEffect), 4, 4)
    };
    public override bool ColdBlood => true;
    public override string Description => "A glowing skull possessed by sorcerous power. It need not move, but merely blast you with mighty magic.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 1;
    public override int FreqSpell => 1;
    public override string FriendlyName => "Skull druj";
    public override int Hdice => 14;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 55;
    public override int Mexp => 25000;
    public override bool NeverMove => true;
    public override int NoticeRange => 20;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Skull\ndruj";
    public override bool Undead => true;
}
