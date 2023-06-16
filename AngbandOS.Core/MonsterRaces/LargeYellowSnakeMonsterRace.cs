// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class LargeYellowSnakeMonsterRace : MonsterRace
{
    protected LargeYellowSnakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override char Character => 'J';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "Large yellow snake";

    public override bool Animal => true;
    public override int ArmourClass => 38;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new CrushAttackType(), new HurtAttackEffect(), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about ten feet long.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Large yellow snake";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override int LevelFound => 2;
    public override int Mexp => 9;
    public override int NoticeRange => 5;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 75;
    public override int Speed => 100;
    public override string SplitName1 => "   Large    ";
    public override string SplitName2 => "   yellow   ";
    public override string SplitName3 => "   snake    ";
}
