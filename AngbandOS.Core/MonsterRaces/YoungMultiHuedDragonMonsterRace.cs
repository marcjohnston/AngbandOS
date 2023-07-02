// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class YoungMultiHuedDragonMonsterRace : MonsterRace
{
    protected YoungMultiHuedDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheAcidMonsterSpell(),
        new BreatheColdMonsterSpell(),
        new BreatheLightningMonsterSpell(),
        new BreatheFireMonsterSpell(),
        new BreathePoisonMonsterSpell(),
        new ScareMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerDSymbol>();
    public override Colour Colour => Colour.Purple;
    public override string Name => "Young multi-hued dragon";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 9),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 9),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 10),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "It has a form that legends are made of. Beautiful scales of shimmering and magical colours cover it.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Young multi-hued dragon";
    public override int Hdice => 32;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 36;
    public override int Mexp => 1320;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 50;
    public override int Speed => 110;
    public override string SplitName1 => "   Young    ";
    public override string SplitName2 => " multi-hued ";
    public override string SplitName3 => "   dragon   ";
}
