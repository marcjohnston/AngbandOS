// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class EnergyHoundMonsterRace : MonsterRace
{
    protected EnergyHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightningMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperZSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightYellow;
    public override string Name => "Energy hound";

    public override bool Animal => true;
    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ElectricityAttackEffect>(), 1, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ElectricityAttackEffect>(), 1, 3),
    };
    public override bool BashDoor => true;
    public override string Description => "Saint Elmo's Fire forms a ghostly halo around this hound, and sparks sting your fingers as energy builds up in the air around you.";
    public override bool ForceSleep => true;
    public override int FreqInate => 10;
    public override int FreqSpell => 10;
    public override string FriendlyName => "Energy hound";
    public override bool Friends => true;
    public override int Hdice => 10;
    public override int Hside => 6;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 18;
    public override int Mexp => 70;
    public override int NoticeRange => 30;
    public override int Rarity => 1;
    public override int Sleep => 0;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Energy   ";
    public override string SplitName3 => "   hound    ";
}