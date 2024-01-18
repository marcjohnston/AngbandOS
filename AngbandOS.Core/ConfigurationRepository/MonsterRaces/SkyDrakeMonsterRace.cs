// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SkyDrakeMonsterRace : MonsterRace
{
    protected SkyDrakeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheLightningMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheGravityMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BreatheLightMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(BlindnessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(ScareMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonDragonMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonHiDragonMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperDSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Sky Drake";

    public override int ArmourClass => 200;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 8, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 8, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(ClawAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 8, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(ElectricityAttackEffect)), 9, 15)
    };
    public override bool BashDoor => true;
    public override string Description => "The mightiest elemental dragon of air, it can destroy you with ease.";
    public override bool Dragon => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Sky Drake";
    public override bool Good => true;
    public override int Hdice => 60;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 69;
    public override bool LightningAura => true;
    public override int Mexp => 31000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool Powerful => true;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 255;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Sky     ";
    public override string SplitName3 => "   Drake    ";
}
