// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GelatinousCubeMonsterRace : MonsterRace
{
    protected GelatinousCubeMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(LowerJSymbol));
    public override ColourEnum Colour => ColourEnum.Diamond;
    public override string Name => "Gelatinous cube";

    public override int ArmourClass => 18;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 1, 10),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(TouchAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(AcidAttackEffect)), 1, 10),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a strange, vast gelatinous structure that assumes cubic proportions as it lines all four walls of the corridors it patrols. Through its transparent jelly structure you can see treasures it has engulfed, and a few corpses as well.";
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Gelatinous cube";
    public override int Hdice => 36;
    public override int Hside => 10;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 16;
    public override int Mexp => 80;
    public override int NoticeRange => 12;
    public override bool OpenDoor => true;
    public override int Rarity => 4;
    public override int Sleep => 1;
    public override int Speed => 110;
    public override string SplitName1 => "            ";
    public override string SplitName2 => " Gelatinous ";
    public override string SplitName3 => "    cube    ";
    public override bool Stupid => true;
    public override bool TakeItem => true;
}
