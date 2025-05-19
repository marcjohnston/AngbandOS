// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HellbatMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerBSymbol);
    public override ColorEnum Color => ColorEnum.Red;
    
    public override bool Animal => true;
    public override int ArmorClass => 80;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 4),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.PoisonAttackEffect), 1, 8),
    };
    public override string Description => "Devil-bats, notoriously difficult to kill.";
    public override bool Evil => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Hellbat";
    public override bool Friends => true;
    public override int Hdice => 12;
    public override int Hside => 12;
    public override bool ImmuneCold => true;
    public override bool ImmuneLightning => true;
    public override bool ImmunePoison => true;
    public override int LevelFound => 13;
    public override int Mexp => 65;
    public override int NoticeRange => 20;
    public override int Rarity => 2;
    public override int Sleep => 8;
    public override int Speed => 110;
    public override string? MultilineName => "Hellbat";
    public override bool WeirdMind => true;
}
