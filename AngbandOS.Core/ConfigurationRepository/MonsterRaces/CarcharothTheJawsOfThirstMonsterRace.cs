// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class CarcharothTheJawsOfThirstMonsterRace : MonsterRace
{
    protected CarcharothTheJawsOfThirstMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BrainSmashMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HealMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHoundMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperCSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "Carcharoth, the Jaws of Thirst";

    public override bool Animal => true;
    public override int ArmourClass => 110;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 3),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 4, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 4, 4)
    };
    public override bool BashDoor => true;
    public override string Description => "The first guard of Angband, Carcharoth, also known as 'The Red Maw', is the largest wolf to ever walk the earth. He is highly intelligent and a deadly opponent in combat.";
    public override bool Drop_1D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Carcharoth, the Jaws of Thirst";
    public override int Hdice => 75;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 92;
    public override bool Male => true;
    public override int Mexp => 40000;
    public override bool MoveBody => true;
    public override int NoticeRange => 80;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Carcharoth ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}