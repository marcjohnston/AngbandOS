// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreatCthulhuMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ChaosBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.ConfusionBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.DarkBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.DisenchantBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.DisintegrationBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NexusBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PlasmaBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.PoisonBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.RadiationBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.MindBlastMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessMonsterSpell),
        nameof(MonsterSpellsEnum.DreadCurseMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell),
        nameof(MonsterSpellsEnum.CthuloidSummonMonsterSpell),
        nameof(MonsterSpellsEnum.HiUndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.KinSummonMonsterSpell),
        nameof(MonsterSpellsEnum.ReaverSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportSelfMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperXSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 140;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 50, 4),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.DrainStaffChargesAttackEffect), 15, 2),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.DrainWandChargesAttackEffect), 15, 2),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 15, 2),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 100)
    };
    public override bool BashDoor => true;
    public override bool Demon => true;
    public override string Description => "This creature is death incarnate. 'A monster of vaguely anthropoid outline, but with an octopus-like head... and long narrow wings behind... A mountain walked or stumbled.'";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Drop_4D2 => true;
    public override bool DropGood => true;
    public override bool DropGreat => true;
    public override bool EldritchHorror => true;
    public override bool Escorted => true;
    public override bool EscortsGroup => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Great Cthulhu";
    public override bool GreatOldOne => true;
    public override int Hdice => 100;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 96;
    public override int Mexp => 62500;
    public override bool MoveBody => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 100;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override int Rarity => 2;
    public override bool Regenerate => true;
    public override bool ResistDisenchant => true;
    public override bool ResistNether => true;
    public override bool ResistNexus => true;
    public override bool ResistPlasma => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 100;
    public override bool Smart => true;
    public override int Speed => 130;
    public override string? MultilineName => "Great\nCthulhu";
    public override bool Unique => true;
}
