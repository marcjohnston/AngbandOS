// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class IthaquaTheWindwalkerMonsterRace : MonsterRace
{
    protected IthaquaTheWindwalkerMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(ColdBreatheBallMonsterSpell),
        nameof(ChaosBallMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(LightningBallMonsterSpell),
        nameof(LightningBoltMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(CthuloidSummonMonsterSpell),
        nameof(HiUndeadSummonMonsterSpell),
        nameof(KinSummonMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    
    public override int ArmorClass => 125;
    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(ColdAttackEffect), 12, 12),
        (nameof(ClawAttack), nameof(ColdAttackEffect), 12, 12),
        (nameof(CrushAttack), nameof(HurtAttackEffect), 12, 12),
        (nameof(CrushAttack), nameof(HurtAttackEffect), 12, 12)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "The Wendigo, moving so fast that you can see little except two glowing eyes burning with hatred.";
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Ithaqua the Windwalker";
    public override bool GreatOldOne => true;
    public override int Hdice => 55;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 82;
    public override bool LightningAura => true;
    public override int Mexp => 32500;
    public override bool Nonliving => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 140;
    public override string? MultilineName => "Ithaqua\nthe\nWindwalker";
    public override bool Unique => true;
}
