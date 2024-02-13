// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WaterPotionItemFactory : PotionItemFactory
{
    private WaterPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Water";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Water";
    public override int InitialTypeSpecificValue => 200;
    public override int Weight => 4;

    public override bool Quaff()
    {
        // Water has no effect
        SaveGame.MsgPrint("You feel less thirsty.");
        return true;
    }

    /// <summary>
    /// Returns null because water potions are always clear flavor.
    /// </summary>
    public override IEnumerable<ReadableFlavor>? GetFlavorRepository()
    {
        Flavor = SaveGame.SingletonRepository.PotionFlavors.Get(nameof(ClearPotionFlavor));
        return null;
    }

    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
