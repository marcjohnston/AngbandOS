// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class HasturTheUnspeakableMonsterRace : MonsterRace
{
    protected HasturTheUnspeakableMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheDarkMonsterSpell(),
        new BreatheNetherMonsterSpell(),
        new BlindnessMonsterSpell(),
        new BrainSmashMonsterSpell(),
        new CauseMortalWoundsMonsterSpell(),
        new DrainManaMonsterSpell(),
        new HoldMonsterSpell(),
        new ScareMonsterSpell(),
        new WaterBallMonsterSpell(),
        new HasteMonsterSpell(),
        new HealMonsterSpell(),
        new SummonCthuloidMonsterSpell(),
        new TeleportAwayMonsterSpell(),
        new TeleportToMonsterSpell(),
        new TeleportSelfMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override ColourEnum Colour => ColourEnum.Blue;
    public override string Name => "Hastur the Unspeakable";

    public override int ArmourClass => 150;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 14, 8),
        new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 14, 8),
        new MonsterAttack(new BiteAttackType(), new Exp80AttackEffect(), 6, 6),
        new MonsterAttack(new BiteAttackType(), new Exp80AttackEffect(), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "Its form is partially that of a reptile, partially that of a gigantic octopus. It will destroy you.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Hastur the Unspeakable";
    public override bool GreatOldOne => true;
    public override int Hdice => 55;
    public override int Hside => 95;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 55;
    public override bool LightningAura => true;
    public override int Mexp => 23000;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "   Hastur   ";
    public override string SplitName2 => "    the     ";
    public override string SplitName3 => "Unspeakable ";
    public override bool Unique => true;
}
