// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CultHighPriestMonsterRace : MonsterRace
{
    protected CultHighPriestMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BrainSmashMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseMortalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HoldMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HealMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonCthuloidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonstersMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonUndeadMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerPSymbol>();
    public override ColourEnum Colour => ColourEnum.Diamond;
    public override string Name => "Cult high priest";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 4),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 5),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 5),
    };
    public override bool BashDoor => true;
    public override string Description => "A dark priest of the highest order. Powerful and evil, beware his many spells.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Cult high priest";
    public override int Hdice => 80;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 44;
    public override bool Male => true;
    public override int Mexp => 5000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "    Cult    ";
    public override string SplitName2 => "    high    ";
    public override string SplitName3 => "   priest   ";
}
