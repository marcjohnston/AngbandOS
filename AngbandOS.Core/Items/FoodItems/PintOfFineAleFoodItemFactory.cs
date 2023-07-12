// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PintOfFineAleFoodItemFactory : FoodItemFactory
{
    private PintOfFineAleFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "Pint of Fine Ale";

    public override int Cost => 1;
    public override string FriendlyName => "& Pint~ of Fine Ale";
    public override int Pval => 500;
    public override int Weight => 5;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        SaveGame.MsgPrint("That tastes good.");
        return true;
    }
    public override Item CreateItem() => new PintOfFineAleFoodItem(SaveGame);
}
