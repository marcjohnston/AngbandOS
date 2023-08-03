// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class ChaosTileMonsterRace : MonsterRace
{
    protected ChaosTileMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseSeriousWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlinkMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonsterMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PeriodSymbol>();
    public override ColourEnum Colour => ColourEnum.Purple;
    public override string Name => "Chaos tile";

    public override int ArmourClass => 60;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<PoisonAttackEffect>(), 3, 4),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ConfuseAttackEffect>(), 3, 4),
    };
    public override bool AttrAny => true;
    public override bool AttrMulti => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "It is a floor tile corrupted by chaos.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Chaos tile";
    public override int Hdice => 3;
    public override int Hside => 5;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 29;
    public override int Mexp => 200;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override int Rarity => 6;
    public override int Sleep => 100;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Chaos    ";
    public override string SplitName3 => "    tile    ";
}
