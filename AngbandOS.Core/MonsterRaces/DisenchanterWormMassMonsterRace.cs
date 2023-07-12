// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DisenchanterWormMassMonsterRace : MonsterRace
{
    protected DisenchanterWormMassMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerWSymbol>();
    public override ColourEnum Colour => ColourEnum.Chartreuse;
    public override string Name => "Disenchanter worm mass";

    public override bool Animal => true;
    public override int ArmourClass => 5;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrawlAttackType(), new UnBonusAttackEffect(), 1, 4),
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "It is a strange mass of squirming worms. Magical energy crackles around its disgusting form.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Disenchanter worm mass";
    public override int Hdice => 10;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 40;
    public override int Mexp => 30;
    public override bool Multiply => true;
    public override int NoticeRange => 7;
    public override bool RandomMove50 => true;
    public override int Rarity => 3;
    public override bool ResistDisenchant => true;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "Disenchanter";
    public override string SplitName2 => "    worm    ";
    public override string SplitName3 => "    mass    ";
    public override bool Stupid => true;
    public override bool WeirdMind => true;
}
