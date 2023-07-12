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
    protected IthaquaTheWindwalkerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheColdMonsterSpell(),
        new ChaosBallMonsterSpell(),
        new CauseMortalWoundsMonsterSpell(),
        new LightningBallMonsterSpell(),
        new LightningBoltMonsterSpell(),
        new ManaBoltMonsterSpell(),
        new MindBlastMonsterSpell(),
        new ScareMonsterSpell(),
        new WaterBallMonsterSpell(),
        new SummonCthuloidMonsterSpell(),
        new SummonHiUndeadMonsterSpell(),
        new SummonKinMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Ithaqua the Windwalker";

    public override int ArmourClass => 125;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new ColdAttackEffect(), 12, 12),
        new MonsterAttack(new ClawAttackType(), new ColdAttackEffect(), 12, 12),
        new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 12, 12),
        new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 12, 12)
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
    public override string SplitName1 => "  Ithaqua   ";
    public override string SplitName2 => "    the     ";
    public override string SplitName3 => " Windwalker ";
    public override bool Unique => true;
}
