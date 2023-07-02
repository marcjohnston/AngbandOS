// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class JackalMonsterRace : MonsterRace
{
    protected JackalMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperCSymbol>();
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Jackal";

    public override bool Animal => true;
    public override int ArmourClass => 3;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 1, 1),
    };
    public override string Description => "It is a yapping snarling dog, dangerous when in a pack.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Jackal";
    public override bool Friends => true;
    public override int Hdice => 1;
    public override int Hside => 4;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override int NoticeRange => 10;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Jackal   ";
}
