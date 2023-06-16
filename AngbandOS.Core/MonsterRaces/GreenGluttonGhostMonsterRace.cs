// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreenGluttonGhostMonsterRace : MonsterRace
{
    protected GreenGluttonGhostMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'G';
    public override Colour Colour => Colour.Green;
    public override string Name => "Green glutton ghost";

    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new EatFoodAttackEffect(), 1, 1),
    };
    public override bool ColdBlood => true;
    public override string Description => "It is a very ugly green ghost with a voracious appetite.";
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Green glutton ghost";
    public override int Hdice => 3;
    public override int Hside => 4;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 5;
    public override int Mexp => 15;
    public override int NoticeRange => 10;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string SplitName1 => "   Green    ";
    public override string SplitName2 => "  glutton   ";
    public override string SplitName3 => "   ghost    ";
    public override bool Undead => true;
}
