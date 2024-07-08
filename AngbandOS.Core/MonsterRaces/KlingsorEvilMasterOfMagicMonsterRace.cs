// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class KlingsorEvilMasterOfMagicMonsterRace : MonsterRace
{
    protected KlingsorEvilMasterOfMagicMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ChaosBallMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(DarkBallMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ManaBallMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(TeleportToMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 100;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 6, 8),
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 6, 8),
        (nameof(TouchAttack), nameof(DrainStaffChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(DrainStaffChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(DrainWandChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(DrainWandChargesAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "Klingsor, whose hopeless effort to join the Knights of the Grail was thwarted, turned to black magic and became a deadly necromancer.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Klingsor, Evil Master of Magic";
    public override int Hdice => 70;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 78;
    public override bool Male => true;
    public override int Mexp => 40000;
    public override int NoticeRange => 60;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Klingsor";
    public override bool Unique => true;
}
