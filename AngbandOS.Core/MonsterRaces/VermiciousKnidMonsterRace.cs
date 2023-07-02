// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VermiciousKnidMonsterRace : MonsterRace
{
    protected VermiciousKnidMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperASymbol>();
    public override Colour Colour => Colour.Brown;
    public override string Name => "Vermicious Knid";

    public override int ArmourClass => 55;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new TouchAttackType(), new TerrifyAttackEffect(), 4, 6),
        new MonsterAttack(new CrawlAttackType(), new HurtAttackEffect(), 4, 6),
        new MonsterAttack(new EngulfAttackType(), new HurtAttackEffect(), 4, 6),
    };
    public override bool ColdBlood => true;
    public override string Description => "An amorphous shape that looks like wet grey clay with two pale eyes. It is totally silent as it oozes towards you.";
    public override bool Drop_2D2 => true;
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Vermicious Knid";
    public override bool Friends => true;
    public override int Hdice => 90;
    public override int Hside => 10;
    public override bool HurtByRock => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 43;
    public override int Mexp => 2100;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 100;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Vermicious ";
    public override string SplitName3 => "    Knid    ";
    public override bool WeirdMind => true;
}
