// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class OmaraxTheEyeTyrantMonsterRace : MonsterRace
{
    protected OmaraxTheEyeTyrantMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new AcidBoltMonsterSpell(),
        new BlindnessMonsterSpell(),
        new ColdBoltMonsterSpell(),
        new ConfuseMonsterSpell(),
        new DarkBallMonsterSpell(),
        new DrainManaMonsterSpell(),
        new FireBoltMonsterSpell(),
        new MindBlastMonsterSpell(),
        new ScareMonsterSpell(),
        new SlowMonsterSpell(),
        new DarknessMonsterSpell(),
        new ForgetMonsterSpell(),
        new SummonKinMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerESymbol>();
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Omarax the Eye Tyrant";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new GazeAttackType(), new Exp40AttackEffect(), 2, 6),
        new MonsterAttack(new GazeAttackType(), new ParalyzeAttackEffect(), 2, 6),
        new MonsterAttack(new GazeAttackType(), new UnPowerAttackEffect(), 2, 6),
        new MonsterAttack(new GazeAttackType(), new LoseIntAttackEffect(), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A disembodied eye, floating in the air. His gaze seems to shred your soul and his spells crush your will. He is ancient, his history steeped in forgotten evils, his atrocities numerous and sickening.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Omarax the Eye Tyrant";
    public override int Hdice => 65;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 73;
    public override bool Male => true;
    public override int Mexp => 16000;
    public override int NoticeRange => 30;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "   Omarax   ";
    public override string SplitName2 => "  the Eye   ";
    public override string SplitName3 => "   Tyrant   ";
    public override bool Unique => true;
}
