// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class StraashaQueenOfAirMonsterRace : MonsterRace
{
    protected StraashaQueenOfAirMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ColdBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<LightningBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<LightningBoltMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperESymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "Straasha, Queen of Air";

    public override int ArmourClass => 50;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 4, 6),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<ConfuseAttackEffect>(), 1, 4),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 4, 6),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<ConfuseAttackEffect>(), 1, 4)
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "A towering air elemental, Straasha, the sorceress, avoids your blows with her extreme speed.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool Female => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 5;
    public override int FreqSpell => 5;
    public override string FriendlyName => "Straasha, Queen of Air";
    public override int Hdice => 27;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool KillBody => true;
    public override bool KillItem => true;
    public override int LevelFound => 44;
    public override bool LightningAura => true;
    public override int Mexp => 8000;
    public override int NoticeRange => 12;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 4;
    public override int Sleep => 50;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "  Straasha  ";
    public override bool Unique => true;
}
