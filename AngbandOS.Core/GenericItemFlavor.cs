// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFlavors;

[Serializable]
internal class GenericItemFlavor : ItemFlavor
{
    public GenericItemFlavor(Game game, ItemFlavorGameConfiguration readableFlavorGameConfiguration) : base(game)
    {
        Key = readableFlavorGameConfiguration.Key ?? readableFlavorGameConfiguration.GetType().Name;
        Name = readableFlavorGameConfiguration.Name;
        SymbolName = readableFlavorGameConfiguration.SymbolName;
        Color = readableFlavorGameConfiguration.Color;
        CanBeAssigned = readableFlavorGameConfiguration.CanBeAssigned;
    }

    public override string Key { get; }
    public override string Name { get; }

    protected override string SymbolName { get; }
    public override ColorEnum Color { get; }
    public override bool CanBeAssigned { get; }
}
