// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class JubjubBirdMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    /// <summary>
    /// Returns true, because this monster has legs and is susceptible to martial arts ankle kicks.
    /// </summary>
    public override bool HasLegs => true;
    public override string SymbolName => nameof(UpperBSymbol);
    public override ColorEnum Color => ColorEnum.Pink;
    
    public override bool Animal => true;
    public override int ArmorClass => 70;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 8, 12),
        (nameof(CrushAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 8, 12),
        (nameof(HitAttack), nameof(AttackEffectsEnum.ElectricityAttackEffect), 12, 12),
    };
    public override bool BashDoor => true;
    public override string Description => "A vast legendary bird, its iron talons rake the most impenetrable of surfaces and its screech echoes through the many winding dungeon corridors.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Jubjub bird";
    public override int Hdice => 80;
    public override int Hside => 13;
    public override bool ImmuneLightning => true;
    public override int LevelFound => 40;
    public override int Mexp => 1000;
    public override int NoticeRange => 20;
    public override int Rarity => 3;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "Jubjub\nbird";
}
