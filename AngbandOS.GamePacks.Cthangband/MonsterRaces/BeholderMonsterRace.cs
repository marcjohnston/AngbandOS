// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BeholderMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.AcidBoltMonsterSpell),
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.ColdBoltMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.FireBoltMonsterSpell),
        nameof(MonsterSpellsEnum.MindBlastMonsterSpell),
        nameof(MonsterSpellsEnum.ScareMonsterSpell),
        nameof(MonsterSpellsEnum.SlowMonsterSpell),
        nameof(MonsterSpellsEnum.DarknessMonsterSpell),
        nameof(MonsterSpellsEnum.ForgetMonsterSpell)
    };

    public override string SymbolName => nameof(LowerESymbol);
    public override ColorEnum Color => ColorEnum.Green;
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(GazeAttack), nameof(AttackEffectsEnum.Exp20AttackEffect), 2, 4),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 2, 4),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.LoseIntAttackEffect), 2, 6),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.DrainStaffChargesAttackEffect), 2, 6),
        (nameof(GazeAttack), nameof(AttackEffectsEnum.DrainWandChargesAttackEffect), 2, 6)
    };
    public override bool BashDoor => true;
    public override string Description => "A disembodied eye, surrounded by twelve smaller eyes on stalks.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 2;
    public override int FreqSpell => 2;
    public override string FriendlyName => "Beholder";
    public override int Hdice => 16;
    public override int Hside => 100;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 38;
    public override int Mexp => 6000;
    public override int NoticeRange => 30;
    public override int Rarity => 4;
    public override bool ResistTeleport => true;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Beholder";
}
