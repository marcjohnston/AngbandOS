// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DreadmasterMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string[]? SpellNames => new string[] {
        nameof(MonsterSpellsEnum.BlindnessMonsterSpell),
        nameof(MonsterSpellsEnum.CauseMortalWoundsMonsterSpell),
        nameof(MonsterSpellsEnum.ConfuseMonsterSpell),
        nameof(MonsterSpellsEnum.DrainManaMonsterSpell),
        nameof(MonsterSpellsEnum.HoldMonsterSpell),
        nameof(MonsterSpellsEnum.NetherBoltMonsterSpell),
        nameof(MonsterSpellsEnum.UndeadSummonMonsterSpell),
        nameof(MonsterSpellsEnum.TeleportLevelMonsterSpell)
    };

    public override string SymbolName => nameof(UpperGSymbol);
    public override ColorEnum Color => ColorEnum.Orange;
    
    public override int ArmorClass => 100;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 6, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 3, 4),
        (nameof(HitAttack), nameof(AttackEffectsEnum.LoseStrAttackEffect), 3, 4)
    };
    public override bool ColdBlood => true;
    public override string Description => "It is an unlife of power almost unequaled. An affront to existence, its very touch abuses and disrupts the flow of life, and its unearthly limbs, of purest black, crush rock and flesh with ease.";
    public override bool Drop_1D2 => true;
    public override bool Drop_4D2 => true;
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 9;
    public override int FreqSpell => 9;
    public override string FriendlyName => "Dreadmaster";
    public override int Hdice => 12;
    public override int Hside => 100;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override bool Invisible => true;
    public override int LevelFound => 44;
    public override int Mexp => 8000;
    public override int NoticeRange => 20;
    public override bool OnlyDropItem => true;
    public override bool PassWall => true;
    public override bool RandomMove25 => true;
    public override int Rarity => 2;
    public override int Sleep => 10;
    public override bool Smart => true;
    public override int Speed => 120;
    public override string? MultilineName => "Dreadmaster";
    public override bool TakeItem => true;
    public override bool Undead => true;
}
