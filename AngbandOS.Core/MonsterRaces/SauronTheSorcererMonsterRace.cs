// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SauronTheSorcererMonsterRace : MonsterRace
{
    protected SauronTheSorcererMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BlindnessMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DarkBallMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(IceBoltMonsterSpell),
        nameof(ManaBallMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(SummonDemonMonsterSpell),
        nameof(SummonHiDragonMonsterSpell),
        nameof(SummonHiUndeadMonsterSpell),
        nameof(SummonMonstersMonsterSpell),
        nameof(TeleportLevelMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(LowerPSymbol);
    public override ColorEnum Color => ColorEnum.Gold;
    
    public override int ArmorClass => 160;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 10, 12),
        (nameof(HitAttack), nameof(DisenchantAttackEffect), 10, 12),
        (nameof(TouchAttack), nameof(DrainStaffChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(DrainStaffChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(DrainWandChargesAttackEffect), 0, 0),
        (nameof(TouchAttack), nameof(DrainWandChargesAttackEffect), 0, 0)
    };
    public override bool BashDoor => true;
    public override string Description => "Mighty in spells and enchantments,he created the One Ring. His eyes glow with power and his gaze seeks to destroy your soul. He has many servants, and rarely fights without them.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Sauron, the Sorcerer";
    public override int Hdice => 105;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 98;
    public override bool Male => true;
    public override int Mexp => 50000;
    public override bool MoveBody => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override bool Reflecting => true;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Sauron";
    public override bool Unique => true;
}
