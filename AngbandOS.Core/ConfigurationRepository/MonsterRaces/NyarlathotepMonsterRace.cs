// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class NyarlathotepMonsterRace : MonsterRace
{
    protected NyarlathotepMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<ChaosBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BrainSmashMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<CauseMortalWoundsMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ConfuseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<IceBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ManaBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ManaBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<NetherBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<PlasmaBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ScareMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<WaterBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DarknessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<DreadCurseMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ForgetMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonCthuloidMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonDemonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonGreatOldOneMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHiDragonMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonHiUndeadMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonMonstersMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<SummonReaverMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportAwayMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportLevelMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportToMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportSelfMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override ColourEnum Colour => ColourEnum.Red;
    public override string Name => "Nyarlathotep";

    public override int ArmourClass => 165;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<UnBonusAttackEffect>(), 12, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<UnPowerAttackEffect>(), 12, 12),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<ConfuseAttackEffect>(), 10, 2),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get<HitAttack>(), SaveGame.SingletonRepository.AttackEffects.Get<BlindAttackEffect>(), 3, 2)
    };
    public override bool AttrMulti => true;
    public override bool BashDoor => true;
    public override string Description => "The Crawling Chaos in it's most monstrous form. It will do all in its power to keep you away from its master, Azathoth.";
    public override bool Drop_2D2 => true;
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool Evil => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Nyarlathotep";
    public override bool GreatOldOne => true;
    public override int Hdice => 99;
    public override int Hside => 111;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 99;
    public override bool LightningAura => true;
    public override int Mexp => 65000;
    public override bool MoveBody => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 1;
    public override bool Reflecting => true;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 0;
    public override bool Smart => true;
    public override int Speed => 145;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "Nyarlathotep";
    public override bool Unique => true;
}