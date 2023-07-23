// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class FthagghuaLordOfTheFireVampiresMonsterRace : MonsterRace
{
    protected FthagghuaLordOfTheFireVampiresMonsterRace(SaveGame saveGame) : base(saveGame) { }

    public override MonsterSpellList Spells => new MonsterSpellList(
        SaveGame.SingletonRepository.MonsterSpells.Get<BreatheFireMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<BlindnessMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBallMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<FireBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<ManaBoltMonsterSpell>(),
        SaveGame.SingletonRepository.MonsterSpells.Get<TeleportToMonsterSpell>());
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<UpperXSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightRed;
    public override string Name => "Fthagghua, Lord of the fire vampires";

    public override int ArmourClass => 160;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 9, 12),
        new MonsterAttack(new HitAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 4, 6),
        new MonsterAttack(new EngulfAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<FireAttackEffect>(), 10, 10),
        new MonsterAttack(new EngulfAttackType(), SaveGame.SingletonRepository.AttackEffects.Get<HurtAttackEffect>(), 10, 10)
    };
    public override bool BashDoor => true;
    public override string Description => "A fiery serpentine entity, streaking through the air like a comet. The heat emanating from this creature is almost unbearable.";
    public override bool Drop_3D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool FireAura => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Fthagghua, Lord of the fire vampires";
    public override bool GreatOldOne => true;
    public override int Hdice => 55;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 56;
    public override int Mexp => 25000;
    public override bool MoveBody => true;
    public override int NoticeRange => 40;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 3;
    public override bool Reflecting => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => " Fthagghua  ";
    public override bool TakeItem => true;
    public override bool Unique => true;
}
