// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FleshGolemMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerGSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    
    public override int ArmorClass => 30;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override string Description => "A shambling humanoid monster with long scars.";
    public override bool EmptyMind => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Flesh golem";
    public override int Hdice => 12;
    public override int Hside => 8;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneLightning => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 14;
    public override int Mexp => 50;
    public override bool Nonliving => true;
    public override int NoticeRange => 12;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Flesh\ngolem";
}
