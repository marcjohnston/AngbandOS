// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class BabyBlueDragonMonsterRace : MonsterRace
{
    protected BabyBlueDragonMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightningMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerDSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Baby blue dragon";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "This hatchling dragon is still soft, its eyes unaccustomed to light and its scales a pale blue.";
    public override bool Dragon => true;
    public override bool Drop_1D2 => true;
    public override bool Drop60 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 11;
    public override int FreqSpell => 11;
    public override string FriendlyName => "Baby blue dragon";
    public override int Hdice => 10;
    public override int Hside => 10;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 9;
    public override int Mexp => 35;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 70;
    public override int Speed => 110;
    public override string SplitName1 => "    Baby    ";
    public override string SplitName2 => "    blue    ";
    public override string SplitName3 => "   dragon   ";
}