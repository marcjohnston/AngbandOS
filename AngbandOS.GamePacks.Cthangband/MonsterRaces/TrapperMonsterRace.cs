// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TrapperMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(PeriodSymbol);
    
    public override int ArmorClass => 75;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 15, 1),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ParalyzeAttackEffect), 15, 1)
    };
    public override bool AttrClear => true;
    public override bool CharClear => true;
    public override bool ColdBlood => true;
    public override string Description => "This creature traps unsuspecting victims and paralyzes them, to be slowly digested later.";
    public override bool EmptyMind => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Trapper";
    public override int Hdice => 60;
    public override int Hside => 10;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 36;
    public override int Mexp => 580;
    public override bool NeverMove => true;
    public override int NoticeRange => 30;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Trapper";
}
