// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GreatStormWyrmMonsterRace : MonsterRace
{
    protected GreatStormWyrmMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheLightningMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperDSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightTurquoise;
    public override string Name => "Great storm wyrm";

    public override int ArmourClass => 150;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 4, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 4, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 4, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<BiteAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ElectricityAttackEffect>(), 5, 14)
    };
    public override bool BashDoor => true;
    public override string Description => "A vast dragon of power. Storms and lightning crash around its titanic form. Deep blue scales reflect the flashes and highlight the creature's great muscles. It regards you with contempt.";
    public override bool Dragon => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Great storm wyrm";
    public override int Hdice => 30;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 51;
    public override bool LightningAura => true;
    public override int Mexp => 17000;
    public override bool MoveBody => true;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override int Sleep => 80;
    public override int Speed => 120;
    public override string SplitName1 => "   Great    ";
    public override string SplitName2 => "   storm    ";
    public override string SplitName3 => "    wyrm    ";
}