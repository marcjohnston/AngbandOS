// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TheStormbringerMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    
    public override int ArmorClass => 99;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(WailAttack), nameof(AttackEffectsEnum.TerrifyAttackEffect), 0, 0),
        (nameof(HitAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 8, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 8, 8),
        (nameof(HitAttack), nameof(AttackEffectsEnum.Exp80AttackEffect), 8, 8)
    };
    public override bool BashDoor => true;
    public override bool CharMulti => true;
    public override bool ColdBlood => true;
    public override string Description => "The mightiest of hellblades, a black runesword which thirsts for your soul.";
    public override bool Evil => true;
    public override bool ForceMaxHp => true;
    public override bool ForceSleep => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "The Stormbringer";
    public override int Hdice => 13;
    public override int Hside => 123;
    public override bool ImmuneCold => true;
    public override bool ImmuneConfusion => true;
    public override bool ImmuneFear => true;
    public override bool ImmuneFire => true;
    public override bool ImmunePoison => true;
    public override bool ImmuneSleep => true;
    public override int LevelFound => 45;
    public override int Mexp => 13333;
    public override bool Nonliving => true;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override bool ResistNether => true;
    public override int Sleep => 20;
    public override int Speed => 120;
    public override string? MultilineName => "The\nStormbringer";
    public override bool Unique => true;
}
