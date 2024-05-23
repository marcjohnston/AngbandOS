// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WeaknessMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private WeaknessMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(CommaSymbol);
    public override string Name => "Weakness";

    public override int DamageDice => 5;
    public override int DamageSides => 5;
    public override string FriendlyName => "Weakness";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 1;

    public override string? EatScriptName => nameof(EatWeaknessScript);
}
