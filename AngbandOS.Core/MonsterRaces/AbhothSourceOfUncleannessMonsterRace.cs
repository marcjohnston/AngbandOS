// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AbhothSourceOfUncleannessMonsterRace : MonsterRace
{
    protected AbhothSourceOfUncleannessMonsterRace(Game game) : base(game) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(NexusBreatheBallMonsterSpell),
        nameof(ChaosBallMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(ManaBallMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(DreadCurseMonsterSpell),
        nameof(HasteMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(CthuloidSummonMonsterSpell),
        nameof(DemonSummonMonsterSpell),
        nameof(HiDragonSummonMonsterSpell),
        nameof(HiUndeadSummonMonsterSpell),
        nameof(HoundSummonMonsterSpell),
        nameof(MonstersSummonMonsterSpell),
        nameof(ReaverSummonMonsterSpell),
        nameof(SpiderSummonMonsterSpell),
        nameof(TeleportAwayMonsterSpell),
        nameof(TeleportLevelMonsterSpell),
        nameof(TeleportToMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    protected override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    
    public override int ArmorClass => 100;

    protected override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(LoseConAttackEffect), 30, 4),
        (nameof(HitAttack), nameof(LoseStrAttackEffect), 30, 4),
        (nameof(TouchAttack), nameof(LoseIntAttackEffect), 1, 50),
        (nameof(CrawlAttack), nameof(LoseWisAttackEffect), 1, 50)
    };

    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "A greyish horrid mass, which quobbs and quivers spawning monstrosities.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Abhoth, Source of Uncleanness";
    public override bool GreatOldOne => true;
    public override int Hdice => 90;
    public override int Hside => 99;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 93;
    public override bool LightningAura => true;
    public override bool Male => true;
    public override int Mexp => 49000;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool PassWall => true;
    public override int Rarity => 3;
    public override bool Regenerate => true;
    public override bool ResistNexus => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Abhoth";
    public override bool Unique => true;
}
