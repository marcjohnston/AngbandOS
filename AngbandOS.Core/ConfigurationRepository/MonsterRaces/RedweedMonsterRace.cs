// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class RedweedMonsterRace : MonsterRace
{
    protected RedweedMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlinkMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<LowerMSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Redweed";

    public override int ArmourClass => 3;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 1),
    };
    public override string Description => "A strange fibrous growth springing up everywhere.";
    public override bool EmptyMind => true;
    public override int FreqInate => 20;
    public override int FreqSpell => 20;
    public override string FriendlyName => "Redweed";
    public override bool Friends => true;
    public override int Hdice => 1;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneFear => true;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 10;
    public override int Rarity => 4;
    public override int Sleep => 10;
    public override int Speed => 100;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Redweed   ";
    public override bool Stupid => true;
}