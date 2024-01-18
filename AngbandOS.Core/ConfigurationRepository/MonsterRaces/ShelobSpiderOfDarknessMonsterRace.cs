// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ShelobSpiderOfDarknessMonsterRace : MonsterRace
{
    protected ShelobSpiderOfDarknessMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheDarkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseCriticalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseMortalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SlowMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CreateTrapsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HealMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonSpiderMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperSSymbol));
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Shelob, Spider of Darkness";

    public override bool Animal => true;
    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 2, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<StingAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 2, 5),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<StingAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseStrAttackEffect>(), 1, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<StingAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 2, 5)
    };
    public override bool BashDoor => true;
    public override string Description => "Shelob is an enormous bloated spider, rumoured to have been one of the brood of Ungoliant the Unlight. Her poison is legendary, as is her ego, which may be her downfall. She used to guard the pass through Cirith Ungol, but has not been seen there for many eons.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Shelob, Spider of Darkness";
    public override int Hdice => 12;
    public override int Hside => 100;
    public override bool HurtByLight => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 32;
    public override int Mexp => 1200;
    public override int NoticeRange => 8;
    public override bool OnlyDropItem => true;
    public override int Rarity => 3;
    public override int Sleep => 80;
    public override bool Smart => true;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Shelob   ";
    public override bool Unique => true;
}
