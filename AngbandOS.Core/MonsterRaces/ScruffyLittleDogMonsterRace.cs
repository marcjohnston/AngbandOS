// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ScruffyLittleDogMonsterRace : MonsterRace
{
    protected ScruffyLittleDogMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperCSymbol>();
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "Scruffy little dog";

    public override bool Animal => true;
    public override int ArmourClass => 1;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 1),
    };
    public override string Description => "A thin flea-ridden mutt, growling as you get close.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Scruffy little dog";
    public override int Hdice => 1;
    public override int Hside => 3;
    public override int LevelFound => 0;
    public override int Mexp => 0;
    public override int NoticeRange => 20;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 5;
    public override int Speed => 110;
    public override string SplitName1 => "  Scruffy   ";
    public override string SplitName2 => "   little   ";
    public override string SplitName3 => "    dog     ";
}
