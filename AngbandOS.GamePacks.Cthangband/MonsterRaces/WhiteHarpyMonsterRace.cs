// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WhiteHarpyMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(UpperHSymbol);
    
    public override bool Animal => true;
    public override int ArmorClass => 17;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 1),
        (nameof(ClawAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 1),
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 2),
    };
    public override string Description => "A flying, screeching bird with a woman's face.";
    public override bool Evil => true;
    public override bool Female => true;
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "White harpy";
    public override int Hdice => 2;
    public override int Hside => 5;
    public override int LevelFound => 2;
    public override int Mexp => 5;
    public override int NoticeRange => 16;
    public override bool RandomMove50 => true;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 110;
    public override string? MultilineName => "White\nharpy";
}
