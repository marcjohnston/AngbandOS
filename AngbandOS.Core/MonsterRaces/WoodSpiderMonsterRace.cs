// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WoodSpiderMonsterRace : MonsterRace
{
    protected WoodSpiderMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperSSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Wood spider";

    public override bool Animal => true;
    public override int ArmourClass => 16;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new StingAttackType(), new PoisonAttackEffect(), 1, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It scuttles towards you.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Wood spider";
    public override bool Friends => true;
    public override int Hdice => 3;
    public override int Hside => 6;
    public override bool ImmunePoison => true;
    public override int LevelFound => 7;
    public override int Mexp => 15;
    public override int NoticeRange => 8;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Wood    ";
    public override string SplitName3 => "   spider   ";
    public override bool WeirdMind => true;
}
