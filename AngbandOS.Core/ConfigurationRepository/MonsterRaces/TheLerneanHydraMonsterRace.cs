// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class TheLerneanHydraMonsterRace : MonsterRace
{
    protected TheLerneanHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BreathePoisonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<PlasmaBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<PoisonBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHydraMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperMSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightTurquoise;
    public override string Name => "The Lernean Hydra";

    public override bool Animal => true;
    public override int ArmourClass => 140;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 8, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 8, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 12, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 12, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A massive legendary hydra. It has twelve powerful heads. Its many eyes stare at you as clouds of smoke and poisonous vapour rise from its seething form.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "The Lernean Hydra";
    public override int Hdice => 45;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override int LevelFound => 55;
    public override int Mexp => 20000;
    public override int NoticeRange => 20;
    public override bool OnlyDropGold => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 20;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string SplitName1 => "    The     ";
    public override string SplitName2 => "  Lernean   ";
    public override string SplitName3 => "   Hydra    ";
    public override bool Unique => true;
}