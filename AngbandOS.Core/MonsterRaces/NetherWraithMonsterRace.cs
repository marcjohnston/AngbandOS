// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NetherWraithMonsterRace : MonsterRace
{
    protected NetherWraithMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseCriticalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<MindBlastMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<NetherBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DarknessMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperWSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Nether wraith";

    public override int ArmourClass => 55;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 12),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 1, 12),
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<Exp80AttackEffect>(), 0, 0),
        new MonsterAttack(new TouchAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<Exp80AttackEffect>(), 0, 0)
    };
    public override bool ColdBlood => true;
    public override string Description => "A form that hurts the eye, death permeates the air around it. As it nears you, a coldness saps your soul.";
    public override bool Drop_4D2 => true;
    public override bool Drop90 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 6;
    public override int FreqSpell => 6;
    public override string FriendlyName => "Nether wraith";
    public override int Hdice => 48;
    public override int Hside => 10;
    public override bool HurtByLight => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 39;
    public override int Mexp => 1700;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "   Nether   ";
    public override string SplitName3 => "   wraith   ";
    public override bool Undead => true;
}
