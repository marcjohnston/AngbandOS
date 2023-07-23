// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class MetallicRedCentipedeMonsterRace : MonsterRace
{
    protected MetallicRedCentipedeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerCSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Metallic red centipede";

    public override bool Animal => true;
    public override int ArmourClass => 9;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrawlAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 2),
    };
    public override bool BashDoor => true;
    public override string Description => "It is about four feet long and carnivorous.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Metallic red centipede";
    public override int Hdice => 4;
    public override int Hside => 8;
    public override int LevelFound => 3;
    public override int Mexp => 12;
    public override int NoticeRange => 8;
    public override bool RandomMove25 => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "  Metallic  ";
    public override string SplitName2 => "    red     ";
    public override string SplitName3 => " centipede  ";
    public override bool WeirdMind => true;
}
