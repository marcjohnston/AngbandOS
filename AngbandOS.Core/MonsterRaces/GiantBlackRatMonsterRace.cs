// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantBlackRatMonsterRace : MonsterRace
{
    protected GiantBlackRatMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerRSymbol>();
    public override Colour Colour => Colour.Black;
    public override string Name => "Giant black rat";

    public override bool Animal => true;
    public override int ArmourClass => 12;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 1, 4),
    };
    public override string Description => "It is a rodent of unusual size.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant black rat";
    public override int Hdice => 2;
    public override int Hside => 3;
    public override bool ImmunePoison => true;
    public override int LevelFound => 9;
    public override int Mexp => 2;
    public override bool Multiply => true;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "   Giant    ";
    public override string SplitName2 => "   black    ";
    public override string SplitName3 => "    rat     ";
}
