// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AppleJuicePotionItemFactory : PotionItemFactory
{
    private AppleJuicePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Apple Juice";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Apple Juice";

    /// <summary>
    /// Returns 250 turns of sustenance for this apply juice food item.
    /// </summary>
    public override int InitialTypeSpecificValue => 250;

    public override int Weight => 4;
    public override bool Quaff()
    {
        // Apple juice has no effect
        SaveGame.MsgPrint("You feel less thirsty.");
        return true;
    }

    /// <summary>
    /// Returns null because the Apple Juice potion is always a light brown flavor.
    /// </summary>
    public override IEnumerable<Flavor>? GetFlavorRepository()
    {
        Flavor = SaveGame.SingletonRepository.PotionFlavors.Get(nameof(LightBrownPotionFlavor));
        return null;
    }

    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
