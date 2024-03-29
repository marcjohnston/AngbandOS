// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ItMonsterRace : MonsterRace
{
    protected ItMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ShriekMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(BlinkMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonHydraMonsterSpell),
        nameof(SummonMonsterMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportAwayMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(PeriodSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    
    public override int ArmorClass => 80;
    protected override MonsterAttackDefinition[]? AttackDefinitions => new MonsterAttackDefinition[]
    {
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(BlindAttackEffect), 8, 8),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(TerrifyAttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(GazeAttack), nameof(Exp40AttackEffect), 0, 0),
        new MonsterAttackDefinition(nameof(TouchAttack), nameof(EatItemAttackEffect), 0, 0)
    };
    public override bool AttrClear => true;
    public override bool CharClear => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "Nobody has ever seen It.";
    public override bool Drop_1D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "It";
    public override int Hdice => 77;
    public override int Hside => 9;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 24;
    public override int Mexp => 400;
    public override int NoticeRange => 25;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 25;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string? MultilineName => "It";
    public override bool Unique => true;
}
