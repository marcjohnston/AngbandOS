// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemFlavors;

/// <summary>
/// Represents a single flavor for a group of items that participate in the IFlavor interface.
/// </summary>
[Serializable]
internal sealed class ItemFlavor : Flavor, IGetKey, IToJson
{
    public ItemFlavor(Game game, ItemFlavorGameConfiguration readableFlavorGameConfiguration) : base(game)
    {
        Key = readableFlavorGameConfiguration.Key ?? readableFlavorGameConfiguration.GetType().Name;
        Name = readableFlavorGameConfiguration.Name;
        SymbolName = readableFlavorGameConfiguration.SymbolName;
        Color = readableFlavorGameConfiguration.Color;
        CanBeAssigned = readableFlavorGameConfiguration.CanBeAssigned;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ItemFlavorGameConfiguration readableFlavorDefinition = new()
        {
            Key = Key,
            SymbolName = SymbolName,
            Color = Color,
            CanBeAssigned = CanBeAssigned,
            Name = Name
        };
        return JsonSerializer.Serialize(readableFlavorDefinition, Game.GetJsonSerializerOptions());
    }

    /// <summary>
    /// This property is bound from the SymbolName property during the binding phase.
    /// </summary>
    public override Symbol Symbol { get; protected set; }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolName);
    }

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is used to bind the Symbol property during the bind phase.
    /// </summary>
    private string SymbolName { get; }
    public override string Name { get; }

    public override ColorEnum Color { get; }
    public override bool CanBeAssigned { get; }
}
