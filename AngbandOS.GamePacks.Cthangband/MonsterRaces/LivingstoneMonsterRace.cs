// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LivingstoneMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(PoundSignSymbol);
    
    public override int ArmorClass => 28;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 5),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 2, 5),
    };
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "A sentient section of wall.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Livingstone";
    public override bool Friends => true;
    public override int Hdice => 6;
    public override int Hside => 8;
    public override bool HurtByRock => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 20;
    public override int Mexp => 56;
    public override bool Multiply => true;
    public override bool NeverMove => true;
    public override int NoticeRange => 45;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Livingstone";
}
