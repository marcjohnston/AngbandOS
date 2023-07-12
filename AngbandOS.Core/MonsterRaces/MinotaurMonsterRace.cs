// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MinotaurMonsterRace : MonsterRace
{
    protected MinotaurMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperHSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Minotaur";

    public override int ArmourClass => 25;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new ButtAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a cross between a human and a bull.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Minotaur";
    public override int Hdice => 100;
    public override int Hside => 10;
    public override int LevelFound => 40;
    public override int Mexp => 2100;
    public override int NoticeRange => 13;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Minotaur  ";
}
