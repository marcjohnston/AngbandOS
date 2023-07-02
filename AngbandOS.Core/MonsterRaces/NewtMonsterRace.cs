// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NewtMonsterRace : MonsterRace
{
    protected NewtMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperRSymbol>();
    public override Colour Colour => Colour.Orange;
    public override string Name => "Newt";

    public override bool Animal => true;
    public override int ArmourClass => 12;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 3),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 3),
    };
    public override string Description => "A small, harmless lizard.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Newt";
    public override int Hdice => 2;
    public override int Hside => 6;
    public override int LevelFound => 1;
    public override int Mexp => 2;
    public override int NoticeRange => 8;
    public override int Rarity => 1;
    public override int Sleep => 30;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "    Newt    ";
    public override bool WeirdMind => true;
}
