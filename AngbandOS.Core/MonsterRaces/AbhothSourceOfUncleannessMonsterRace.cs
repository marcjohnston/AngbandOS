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
    protected AbhothSourceOfUncleannessMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheNexusMonsterSpell(),
        new ChaosBallMonsterSpell(),
        new BrainSmashMonsterSpell(),
        new CauseMortalWoundsMonsterSpell(),
        new FireBallMonsterSpell(),
        new ManaBallMonsterSpell(),
        new MindBlastMonsterSpell(),
        new DreadCurseMonsterSpell(),
        new HasteMonsterSpell(),
        new HealMonsterSpell(),
        new SummonCthuloidMonsterSpell(),
        new SummonDemonMonsterSpell(),
        new SummonHiDragonMonsterSpell(),
        new SummonHiUndeadMonsterSpell(),
        new SummonHoundMonsterSpell(),
        new SummonMonstersMonsterSpell(),
        new SummonReaverMonsterSpell(),
        new SummonSpiderMonsterSpell(),
        new TeleportAwayMonsterSpell(),
        new TeleportLevelMonsterSpell(),
        new TeleportToMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Abhoth, Source of Uncleanness";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrushAttackType(), new LoseConAttackEffect(), 30, 4),
        new MonsterAttack(new HitAttackType(), new LoseStrAttackEffect(), 30, 4),
        new MonsterAttack(new TouchAttackType(), new LoseIntAttackEffect(), 1, 50),
        new MonsterAttack(new CrawlAttackType(), new LoseWisAttackEffect(), 1, 50)
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
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Abhoth   ";
    public override bool Unique => true;
}
