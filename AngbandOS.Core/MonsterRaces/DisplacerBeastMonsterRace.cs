// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DisplacerBeastMonsterRace : MonsterRace
{
    protected DisplacerBeastMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerFSymbol>();
    public override Colour Colour => Colour.Blue;
    public override string Name => "Displacer beast";

    public override bool Animal => true;
    public override int ArmourClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 8),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a huge black panther, clubbed tentacles sprouting from its shoulders.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Displacer beast";
    public override int Hdice => 25;
    public override int Hside => 10;
    public override bool Invisible => true;
    public override int LevelFound => 26;
    public override int Mexp => 100;
    public override int NoticeRange => 35;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Displacer  ";
    public override string SplitName3 => "   beast    ";
}
