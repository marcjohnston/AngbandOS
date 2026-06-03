// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GlaakiMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBoltProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashScriptMonsterSpell),
        nameof(MonsterSpellsEnum.CauseCriticalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBallProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseScriptMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaScriptMonsterSpell),
        nameof(MonsterSpellsEnum.FireBallProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.HoldScriptMonsterSpell),
        nameof(MonsterSpellsEnum.ManaBoltProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBallProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBoltProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.PlasmaBoltProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ScareScriptMonsterSpell),
        nameof(MonsterSpellsEnum.WaterBallProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.WaterBoltProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.CreateTrapsScriptMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessProjectileMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetScriptMonsterSpell),
        nameof(MonsterSpellsEnum.HealScriptMonsterSpell),
        nameof(MonsterSpellsEnum.MonsterSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportAwayScriptMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportToScriptMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportSelfScriptMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperXSymbol);
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 15),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 10, 15),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseConAttackEffect), 10, 15),
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
    public override string? MultilineName => "Glaaki";
    public override bool Unique => true;
}
