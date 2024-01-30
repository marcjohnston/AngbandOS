// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GiantBlackDragonFlyMonsterRace : MonsterRace
{
    protected GiantBlackDragonFlyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(BreatheAcidMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperFSymbol));
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Giant black dragon fly";

    public override bool Animal => true;
    public override int ArmorClass => 20;
    public override MonsterAttack[]? Attacks => null;
    public override bool BashDoor => true;
    public override string Description => "The size of a large bird, this fly drips caustic acid.";
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Giant black dragon fly";
    public override int Hdice => 3;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 18;
    public override int Mexp => 68;
    public override bool NeverAttack => true;
    public override int NoticeRange => 12;
    public override bool RandomMove25 => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 2;
    public override int Sleep => 50;
    public override int Speed => 120;
    public override string SplitName1 => "Giant black ";
    public override string SplitName2 => "   dragon   ";
    public override string SplitName3 => "    fly     ";
    public override bool WeirdMind => true;
}
