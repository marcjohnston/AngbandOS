// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class StarSpawnOfCthulhuMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.FireBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBreatheBallMonsterSpell),
        nameof(MonsterSpellsEnum.RadiationBallMonsterSpell),
        nameof(MonsterSpellsEnum.BrainSmashMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.MindBlastMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.HealMonsterSpell),
        nameof(MonsterSpellsEnum.CthuloidSummonMonsterSpell),
        nameof(MonsterSpellsEnum.MonstersSummonMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportSelfMonsterSpell)
    };


    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperUSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    
    public override int ArmorClass => 90;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 30),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.AcidAttackEffect), 1, 30),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.DrainStaffChargesAttackEffect), 1, 10),
        (nameof(TouchAttack), nameof(AttackEffectsEnum.DrainWandChargesAttackEffect), 1, 10),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.DisenchantAttackEffect), 2, 33)
    };
    public override bool BashDoor => true;
    public override bool Cthuloid => true;
    public override string Description => "The last remnants of sanity threaten to leave your brain as you behold this titanic bat-winged, octopus-headed unholy abomination.";
    public override bool Drop_1D2 => true;
    public override bool Drop_2D2 => true;
    public override bool Drop90 => true;
    public override bool EldritchHorror => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 3;
    public override int FreqSpell => 3;
    public override string FriendlyName => "Star-spawn of Cthulhu";
    public override int Hdice => 75;
    public override int Hside => 100;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool KillItem => true;
    public override int LevelFound => 86;
    public override int Mexp => 44000;
    public override bool Nonliving => true;
    public override int NoticeRange => 90;
    public override bool OnlyDropItem => true;
    public override bool OpenDoor => true;
    public override bool Powerful => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override bool ResistNether => true;
    public override bool ResistTeleport => true;
    public override int Sleep => 90;
    public override int Speed => 130;
    public override string? MultilineName => "Star-spawn\nof\nCthulhu";
}
