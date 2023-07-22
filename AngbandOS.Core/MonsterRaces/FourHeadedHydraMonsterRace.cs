// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FourHeadedHydraMonsterRace : MonsterRace
{
    protected FourHeadedHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperMSymbol>();
    public override ColourEnum Colour => ColourEnum.Chartreuse;
    public override string Name => "4-headed hydra";

    public override bool Animal => true;
    public override int ArmourClass => 70;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
        new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A strange reptilian hybrid with four heads, guarding its hoard.";
    public override bool Drop_4D2 => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 7;
    public override int FreqSpell => 7;
    public override string FriendlyName => "4-headed hydra";
    public override int Hdice => 100;
    public override int Hside => 6;
    public override int LevelFound => 24;
    public override int Mexp => 350;
    public override bool MoveBody => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  4-headed  ";
    public override string SplitName3 => "   hydra    ";
}
