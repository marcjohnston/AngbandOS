// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class VecnaTheEmperorLichMonsterRace : MonsterRace
{
    protected VecnaTheEmperorLichMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BrainSmashMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseCriticalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseMortalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HoldMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ManaBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ManaBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<NetherBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlinkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CreateTrapsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonKinMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonstersMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonUndeadMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportToMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperLSymbol>();
    public override ColourEnum Colour => ColourEnum.Gold;
    public override string Name => "Vecna, the Emperor Lich";

    public override int ArmourClass => 85;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<Exp80AttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<UnPowerAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseDexAttackEffect>(), 2, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseDexAttackEffect>(), 2, 12)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "He is a highly cunning, extremely magical being, spoken of in legends. This ancient shadow of death wilts any living thing it passes.";
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Escorted => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Vecna, the Emperor Lich";
    public override int Hdice => 50;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 72;
    public override bool Male => true;
    public override int Mexp => 30000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 50;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Vecna    ";
    public override bool Undead => true;
    public override bool Unique => true;
}