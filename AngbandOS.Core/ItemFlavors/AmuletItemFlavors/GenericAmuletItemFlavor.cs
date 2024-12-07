// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFlavors;

[Serializable]
internal class GenericAmuletItemFlavor : AmuletItemFlavor
{
    public GenericAmuletItemFlavor(Game game, ReadableFlavorGameConfiguration readableFlavorDefninition) : base(game)
    {
        Key = readableFlavorDefninition.Key;
        Name = readableFlavorDefninition.Name;
        SymbolName = readableFlavorDefninition.SymbolName;
        Color = readableFlavorDefninition.Color;
        CanBeAssigned = readableFlavorDefninition.CanBeAssigned;
    }

    public override string Key { get; }
    public override string Name { get; }

    protected override string SymbolName { get; }
    public override ColorEnum Color { get; }
    public override bool CanBeAssigned { get; }
}
