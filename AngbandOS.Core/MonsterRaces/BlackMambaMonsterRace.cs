// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlackMambaMonsterRace : MonsterRace
{
    protected BlackMambaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperJSymbol>();
    public override Colour Colour => Colour.Black;
    public override string Name => "Black mamba";

    public override bool Animal => true;
    public override int ArmourClass => 32;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new PoisonAttackEffect(), 4, 4),
    };
    public override bool BashDoor => true;
    public override string Description => "It has glistening black skin, a sleek body and highly venomous fangs.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Black mamba";
    public override int Hdice => 10;
    public override int Hside => 8;
    public override bool ImmunePoison => true;
    public override int LevelFound => 12;
    public override int Mexp => 40;
    public override int NoticeRange => 10;
    public override bool RandomMove50 => true;
    public override int Rarity => 3;
    public override int Sleep => 1;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Black    ";
    public override string SplitName3 => "   mamba    ";
}
