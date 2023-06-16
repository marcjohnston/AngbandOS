// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class YoungWhiteDragonMonsterRace : MonsterRace
{
    protected YoungWhiteDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheColdMonsterSpell(),
        new ScareMonsterSpell());
    public override char Character => 'd';
    public override string Name => "Young white dragon";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It has a form that legends are made of. Its still-tender scales are a frosty white in hue. Icy blasts of cold air come from it as it breathes.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Young white dragon";
    public override int Hdice => 27;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override int LevelFound => 29;
    public override int Mexp => 275;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "   Young    ";
    public override string SplitName2 => "   white    ";
    public override string SplitName3 => "   dragon   ";
}
