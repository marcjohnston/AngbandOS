// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FormlessSpawnOfTsathogguaMonsterRace : MonsterRace
{
    protected FormlessSpawnOfTsathogguaMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(AcidBoltMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(FireBoltMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(MindBlastMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(DarknessMonsterSpell)),
        SaveGame.SingletonRepository.MonsterSpells.Get(nameof(SummonCthuloidMonsterSpell)));
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperASymbol));
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "Formless spawn of Tsathoggua";

    public override int ArmourClass => 40;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 2, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 2, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 3, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(BiteAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 6, 6)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "A black, protean being of amorphous slime.";
    public override bool Drop90 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Formless spawn of Tsathoggua";
    public override int Hdice => 22;
    public override int Hside => 20;
    public override bool HurtByFire => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 41;
    public override int Mexp => 1850;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 80;
    public override int Speed => 110;
    public override string SplitName1 => "  Formless  ";
    public override string SplitName2 => "  spawn of  ";
    public override string SplitName3 => " Tsathoggua ";
}
