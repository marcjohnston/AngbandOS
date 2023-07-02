// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class WaterHoundMonsterRace : MonsterRace
{
    protected WaterHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        new BreatheAcidMonsterSpell());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperZSymbol>();
    public override Colour Colour => Colour.Blue;
    public override string Name => "Water hound";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new AcidAttackEffect(), 2, 8),
        new MonsterAttack(new BiteAttackType(), new AcidAttackEffect(), 2, 8),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3),
        new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3)
    };
    public override bool BashDoor => true;
    public override string Description => "Liquid footprints follow this hound as it pads around the dungeon. An acrid smell of acid rises from the dog's pelt.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Water hound";
    public override bool Friends => true;
    public override int Hdice => 15;
    public override int Hside => 8;
    public override bool ImmuneAcid => true;
    public override int LevelFound => 20;
    public override int Mexp => 200;
    public override int NoticeRange => 30;
    public override int Rarity => 2;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Water    ";
    public override string SplitName3 => "   hound    ";
}
