// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GiantSkeletonTrollMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(LowerSSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    
    public override int ArmorClass => 50;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 9),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 9),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 6),
    };
    public override bool BashDoor => true;
    public override bool ColdBlood => true;
    public override string Description => "It is the animated form of a massive troll.";
    public override bool EmptyMind => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Giant skeleton troll";
    public override int Hdice => 45;
    public override int Hside => 10;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 33;
    public override int Mexp => 325;
    public override int NoticeRange => 20;
    public override bool OpenDoor => true;
    public override int Rarity => 1;
    public override int Sleep => 20;
    public override int Speed => 110;
    public override string? MultilineName => "Giant\nskeleton\ntroll";
    public override bool Troll => true;
    public override bool Undead => true;
}
