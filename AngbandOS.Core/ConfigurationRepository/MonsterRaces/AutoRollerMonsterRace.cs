// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class AutoRollerMonsterRace : MonsterRace
{
    protected AutoRollerMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerGSymbol));
    public override string Name => "Auto-roller";

    public override int ArmourClass => 80;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 7),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(CrushAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 1, 8)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It looks like a huge spiked roller, moving on its own towards you.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Auto-roller";
    public override int Hdice => 70;
    public override int Hside => 12;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 22;
    public override int Mexp => 230;
    public override bool Nonliving => true;
    public override int NoticeRange => 10;
    public override int Rarity => 2;
    public override bool ResistTeleport => true;
    public override int Sleep => 12;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Auto-roller ";
}
