// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PintOfFineAleFoodItemFactory : FoodItemFactory
{
    private PintOfFineAleFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Pint of Fine Ale";

    public override int Cost => 1;
    public override string FriendlyName => "& Pint~ of Fine Ale";
    public override int InitialNutritionalValue => 500;
    public override int Weight => 5;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.MsgPrint("That tastes good.");
        return true;
    }
}
