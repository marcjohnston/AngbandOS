// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class OozeElementalMonsterRace : MonsterRace
{
    protected OozeElementalMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<AcidBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<AcidBoltMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperESymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "Ooze elemental";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<AcidAttackEffect>(), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a towering mass of filth, an eyesore of ooze.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Ooze elemental";
    public override int Hdice => 13;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 35;
    public override int Mexp => 300;
    public override int NoticeRange => 10;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override int Sleep => 90;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Ooze    ";
    public override string SplitName3 => " elemental  ";
}