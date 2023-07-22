// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BlueIckyThingMonsterRace : MonsterRace
{
    protected BlueIckyThingMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerISymbol>();
    public override ColourEnum Colour => ColourEnum.Blue;
    public override string Name => "Blue icky thing";

    public override int ArmourClass => 20;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new CrawlAttackType(), new PoisonAttackEffect(), 1, 4),
        new MonsterAttack(new CrawlAttackType(), new EatFoodAttackEffect(), 0, 0),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 4),
        new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 4)
    };
    public override bool BashDoor => true;
    public override string Description => "It is a strange, slimy, icky creature, with rudimentary intelligence, but evil cunning. It hungers for food, and you look tasty.";
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 8;
    public override int FreqSpell => 8;
    public override string FriendlyName => "Blue icky thing";
    public override int Hdice => 10;
    public override int Hside => 6;
    public override bool ImmunePoison => true;
    public override int LevelFound => 14;
    public override int Mexp => 20;
    public override bool Multiply => true;
    public override int NoticeRange => 15;
    public override bool OpenDoor => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 100;
    public override string SplitName1 => "    Blue    ";
    public override string SplitName2 => "    icky    ";
    public override string SplitName3 => "   thing    ";
}
