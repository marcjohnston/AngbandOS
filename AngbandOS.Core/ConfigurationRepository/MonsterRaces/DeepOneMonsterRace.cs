// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class DeepOneMonsterRace : MonsterRace
{
    protected DeepOneMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<MagicMissileMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ForgetMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerHSymbol>();
    public override ColourEnum Colour => ColourEnum.Green;
    public override string Name => "Deep One";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 3, 4),
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A batrachian humanoid with large eyes and a scaly skin suggestive of fishskin, hopping irregularly and casting spells with a croaking, baying voice.";
    public override bool Drop_2D2 => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Deep One";
    public override int Hdice => 30;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 26;
    public override int Mexp => 220;
    public override int NoticeRange => 30;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 6;
    public override int Sleep => 255;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "    Deep    ";
    public override string SplitName3 => "    One     ";
    public override bool TakeItem => true;
}