// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AncientBronzeDragonMonsterRace : MonsterRace
{
    protected AncientBronzeDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheConfusionMonsterSpell(),
        new BlindnessMonsterSpell(),
        new ConfuseMonsterSpell(),
        new ScareMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperDSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Ancient bronze dragon";

    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 8),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 4, 8),
        new MonsterAttack(new BiteAttackType(), new ColdAttackEffect(), 5, 10),
    };
    public override bool BashDoor => true;
    public override string Description => "A huge draconic form enveloped in a cascade of colour.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Ancient bronze dragon";
    public override int Hdice => 73;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 1700;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 200;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "  Ancient   ";
    public override string SplitName2 => "   bronze   ";
    public override string SplitName3 => "   dragon   ";
}
