// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatCthulhuMonsterRace : MonsterRace
{
    protected GreatCthulhuMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBreatheBallMonsterSpell),
        nameof(ChaosBreatheBallMonsterSpell),
        nameof(ConfusionBreatheBallMonsterSpell),
        nameof(DarkBreatheBallMonsterSpell),
        nameof(DisenchantBreatheBallMonsterSpell),
        nameof(DisintegrationBreatheBallMonsterSpell),
        nameof(FireBreatheBallMonsterSpell),
        nameof(NetherBreatheBallMonsterSpell),
        nameof(NexusBreatheBallMonsterSpell),
        nameof(PlasmaBreatheBallMonsterSpell),
        nameof(PoisonBreatheBallMonsterSpell),
        nameof(RadiationBreatheBallMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(CthuloidSummonMonsterSpell),
        nameof(HiUndeadSummonMonsterSpell),
        nameof(KinSummonMonsterSpell),
        nameof(ReaverSummonMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 140;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(HurtAttackEffect), 50, 4),
        (nameof(ClawAttack), nameof(DrainStaffChargesAttackEffect), 15, 2),
        (nameof(ClawAttack), nameof(DrainWandChargesAttackEffect), 15, 2),
        (nameof(ClawAttack), nameof(DisenchantAttackEffect), 15, 2),
        (nameof(TouchAttack), nameof(PoisonAttackEffect), 1, 100)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "This creature is death incarnate. 'A monster of vaguely anthropoid outline, but with an octopus-like head... and long narrow wings behind... A mountain walked or stumbled.'";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EldritchHorror => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Cthulhu";
    public override bool GreatOldOne => true;
    public override int Hdice => 100;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 96;
    public override int Mexp => 62500;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override bool ResistDisenchant => true;
    public override bool ResistNether => true;
    public override bool ResistNexus => true;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 100;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Great\nCthulhu";
    public override bool Unique => true;
}
