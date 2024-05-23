// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RestoringMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private RestoringMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override string Name => "Restoring";

    public override int Cost => 1000;
    public override string FriendlyName => "Restoring";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 8),
        (30, 4),
        (40, 1)
    };
    public override int Weight => 1;
    public override string? EatScriptName => nameof(EatRestoringScript);
}
