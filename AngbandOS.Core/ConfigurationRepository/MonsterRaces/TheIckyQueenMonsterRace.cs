// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TheIckyQueenMonsterRace : MonsterRace
{
    protected TheIckyQueenMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DrainManaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerISymbol>();
    public override ColourEnum Colour => ColourEnum.Chartreuse;
    public override string Name => "The Icky Queen";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrawlAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 3, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrawlAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<EatFoodAttackEffect>(), 3, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 3, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "And you thought her offspring were icky!";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "The Icky Queen";
    public override int Hdice => 40;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 20;
    public override int Mexp => 400;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 5;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "    The     ";
    public override string SplitName2 => "    Icky    ";
    public override string SplitName3 => "   Queen    ";
    public override bool TakeItem => true;
    public override bool Unique => true;
    public override bool WeirdMind => true;
}