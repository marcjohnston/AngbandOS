// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NyogthaTheThingThatShouldNotBeMonsterRace : MonsterRace
{
    protected NyogthaTheThingThatShouldNotBeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheAcidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheDarkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheRadiationMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BrainSmashMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<MindBlastMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HasteMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonCthuloidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHiUndeadMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonKinMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonUndeadMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportSelfMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Nyogtha, the Thing that Should not Be";

    public override int ArmourClass => 120;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 10, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ColdAttackEffect>(), 10, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 10, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<CrushAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 16, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A nightmarish fetid, black irididescence oozing towards you.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Nyogtha, the Thing that Should not Be";
    public override bool GreatOldOne => true;
    public override int Hdice => 55;
    public override int Hside => 99;
    public override bool HurtByLight => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 56;
    public override int Mexp => 20000;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override bool ResistNether => true;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Nyogtha   ";
    public override bool Unique => true;
}