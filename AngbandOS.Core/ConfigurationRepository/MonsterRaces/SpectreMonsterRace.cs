// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class SpectreMonsterRace : MonsterRace
{
    protected SpectreMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DrainManaMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<HoldMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ForgetMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperGSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "Spectre";

    public override int ArmourClass => 30;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<WailAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<TerrifyAttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<TouchAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<Exp40AttackEffect>(), 0, 0),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<ClawAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<LoseWisAttackEffect>(), 5, 5),
    };
    public override bool ColdBlood => true;
    public override string Description => "A phantasmal shrieking spirit. Its wail drives the intense cold of pure evil deep within your body.";
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 16;
    public override int FreqSpell => 16;
    public override string FriendlyName => "Spectre";
    public override int Hdice => 14;
    public override int Hside => 20;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 350;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Spectre   ";
    public override bool TakeItem => true;
    public override bool Undead => true;
}