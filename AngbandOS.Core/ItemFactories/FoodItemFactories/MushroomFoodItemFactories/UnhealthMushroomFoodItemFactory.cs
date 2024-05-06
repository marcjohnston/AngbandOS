// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class UnhealthMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private UnhealthMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override string Name => "Unhealth";

    public override int Cost => 50;
    public override int DamageDice => 10;
    public override int DamageSides => 10;
    public override string FriendlyName => "Unhealth";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override int Weight => 1;
    public override bool Eat()
    {
        return Game.RunIdentifableScript(nameof(EatUnhealthScript));
    }
}
