// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BeholderMonsterRace : MonsterRace
{
    protected BeholderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBoltMonsterSpell),
        nameof(BlindnessMonsterSpell),
        nameof(ColdBoltMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(FireBoltMonsterSpell),
        nameof(MindBlastMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(SlowMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(ForgetMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerESymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Beholder";

    public override int ArmorClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(Exp20AttackEffect)), 2, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ParalyzeAttackEffect)), 2, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseIntAttackEffect)), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(GazeAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(UnPowerAttackEffect)), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A disembodied eye, surrounded by twelve smaller eyes on stalks.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Beholder";
    public override int Hdice => 16;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 6000;
    public override int NoticeRange => 30;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Beholder  ";
}
