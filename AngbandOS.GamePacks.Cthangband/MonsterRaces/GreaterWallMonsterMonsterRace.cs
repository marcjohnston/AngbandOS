// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreaterWallMonsterMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(PoundSignSymbol);
    
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
        (nameof(HitAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 3, 6),
    };
    public override bool BashDoor => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "A sentient, moving section of wall.";
    public override bool EmptyMind => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Greater wall monster";
    public override int Hdice => 15;
    public override int Hside => 40;
    public override bool HurtByRock => true;
    public override bool ImmuneAcid => true;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFire => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 50;
    public override int Mexp => 900;
    public override bool Multiply => true;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override bool PassWall => true;
    public override bool RandomMove50 => true;
    public override int Rarity => 4;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "Greater\nwall\nmonster";
}
