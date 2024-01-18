// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpottedJellyMonsterRace : MonsterRace
{
    protected SpottedJellyMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerJSymbol));
    public override ColourEnum Colour => ColourEnum.BrightPink;
    public override string Name => "Spotted jelly";

    public override int ArmourClass => 18;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 2, 6),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 1, 10),
    };
    public override bool ColdBlood => true;
    public override string Description => "A jelly thing.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Spotted jelly";
    public override int Hdice => 13;
    public override int Hside => 8;
    public override bool HurtByLight => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 12;
    public override int Mexp => 33;
    public override bool NeverMove => true;
    public override int NoticeRange => 12;
    public override int Rarity => 3;
    public override int Sleep => 1;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "  Spotted   ";
    public override string SplitName3 => "   jelly    ";
    public override bool Stupid => true;
}
