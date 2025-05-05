namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MushroomItemClass : ItemClassGameConfiguration
{
    public override string Name => "Mushroom";

    /// <summary>
    /// Returns the mushroom flavors repository because mushrooms have flavors that need to be identified.
    /// </summary>
    public override string[] ItemFlavorBindingKeys => new string[]
    {
        nameof(BlackMushroomItemFlavor),
        nameof(BlackSpottedMushroomItemFlavor),
        nameof(BlueMushroomItemFlavor),
        nameof(BrownMushroomItemFlavor),
        nameof(DarkBlueMushroomItemFlavor),
        nameof(DarkGreenMushroomItemFlavor),
        nameof(DarkRedMushroomItemFlavor),
        nameof(FurryMushroomItemFlavor),
        nameof(GreenMushroomItemFlavor),
        nameof(GreyMushroomItemFlavor),
        nameof(LightBlueMushroomItemFlavor),
        nameof(LightGreenMushroomItemFlavor),
        nameof(RedMushroomItemFlavor),
        nameof(SlimyMushroomItemFlavor),
        nameof(TanMushroomItemFlavor),
        nameof(VioletMushroomItemFlavor),
        nameof(WhiteMushroomItemFlavor),
        nameof(WhiteSpottedMushroomItemFlavor),
        nameof(WrinkledMushroomItemFlavor),
        nameof(YellowMushroomItemFlavor),
  };
}