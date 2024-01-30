// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal class GlaakiMonsterRace : MonsterRace
{
    protected GlaakiMonsterRace(SaveGame saveGame) : base(saveGame) { }

    protected override string[]? SpellNames =>new string[] {
        nameof(AcidBoltMonsterSpell),
        nameof(BrainSmashMonsterSpell),
        nameof(CauseCriticalWoundsMonsterSpell),
        nameof(CauseMortalWoundsMonsterSpell),
        nameof(ColdBallMonsterSpell),
        nameof(ConfuseMonsterSpell),
        nameof(DrainManaMonsterSpell),
        nameof(FireBallMonsterSpell),
        nameof(HoldMonsterSpell),
        nameof(ManaBoltMonsterSpell),
        nameof(NetherBallMonsterSpell),
        nameof(NetherBoltMonsterSpell),
        nameof(PlasmaBoltMonsterSpell),
        nameof(ScareMonsterSpell),
        nameof(WaterBallMonsterSpell),
        nameof(WaterBoltMonsterSpell),
        nameof(CreateTrapsMonsterSpell),
        nameof(DarknessMonsterSpell),
        nameof(ForgetMonsterSpell),
        nameof(HealMonsterSpell),
        nameof(SummonMonsterMonsterSpell),
        nameof(SummonUndeadMonsterSpell),
        nameof(TeleportAwayMonsterSpell),
        nameof(TeleportToMonsterSpell),
        nameof(TeleportSelfMonsterSpell)
    };

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UpperXSymbol));
    public override string Name => "Glaaki";

    public override int ArmorClass => 100;
    public override MonsterAttack[]? Attacks => new MonsterAttack[] {
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 10, 15),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(HurtAttackEffect)), 10, 15),
        new MonsterAttack(SaveGame.SingletonRepository.Attacks.Get(nameof(HitAttack)), SaveGame.SingletonRepository.AttackEffects.Get(nameof(LoseConAttackEffect)), 10, 15),
    };
    public override bool BashDoor => true;
    public override string Description => "Oval bodied with countless thin spines, and three baleful yellow eyes on thin stalks.";
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Drop60 => true;
    public override bool Drop90 => true;
    public override bool DropGood => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 4;
    public override int FreqSpell => 4;
    public override string FriendlyName => "Glaaki";
    public override bool GreatOldOne => true;
    public override int Hdice => 59;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 78;
    public override bool Male => true;
    public override int Mexp => 35500;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override bool Regenerate => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 15;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string SplitName1 => "            ";
    public override string SplitName2 => "            ";
    public override string SplitName3 => "   Glaaki   ";
    public override bool Unique => true;
}
