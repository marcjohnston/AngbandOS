// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MatureBlueDragonMonsterRace : MonsterRace
{
    protected MatureBlueDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheLightningMonsterSpell(),
        new ScareMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerDSymbol>();
    public override ColourEnum Colour => ColourEnum.Blue;
    public override string Name => "Mature blue dragon";

    public override int ArmourClass => 75;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 8),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "A large dragon, scales tinted deep blue.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Mature blue dragon";
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 1200;
    public override int NoticeRange => 20;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "   Mature   ";
    public override string SplitName2 => "    blue    ";
    public override string SplitName3 => "   dragon   ";
}
