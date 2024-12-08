// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFlavors;

[Serializable]
internal class GenericStaffItemFlavor : StaffItemFlavor
{
    public GenericStaffItemFlavor(Game game, ItemFlavorGameConfiguration readableFlavorDefinition) : base(game)
    {
        Key = readableFlavorDefinition.Key;
        Name = readableFlavorDefinition.Name;
        SymbolName = readableFlavorDefinition.SymbolName;
        Color = readableFlavorDefinition.Color;
        CanBeAssigned = readableFlavorDefinition.CanBeAssigned;
    }

    public override string Key { get; }
    public override string Name { get; }

    protected override string SymbolName { get; }
    public override ColorEnum Color { get; }
    public override bool CanBeAssigned { get; }
}
