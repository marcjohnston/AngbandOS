// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FruitBatMonsterRace : MonsterRaceGameConfiguration
{
    public override string GoldItemFactoryBindingKey => nameof(LotOfGoldGoldItemFactory);
    public override string SymbolName => nameof(LowerBSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    
    public override bool Animal => true;
    public override int ArmorClass => 3;
    public override (string, string?, int, int)[]? AttackDefinitions => new (string, string?, int, int)[]
    {
        (nameof(BiteAttack), nameof(AttackEffectsEnum.HurtAttackEffect), 1, 1),
    };
    public override string Description => "A fast-moving pest.";
    public override int FreqInate => 0;
    public override int FreqSpell => 0;
    public override string FriendlyName => "Fruit bat";
    public override int Hdice => 1;
    public override int Hside => 6;
    public override int LevelFound => 1;
    public override int Mexp => 1;
    public override int NoticeRange => 20;
    public override int Rarity => 1;
    public override int Sleep => 10;
    public override int Speed => 120;
    public override string? MultilineName => "Fruit\nbat";
}
