// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.ItemFlavors;

/// <summary>
/// Represents a single flavor for a group of items that participate in the IFlavor interface.
/// </summary>
[Serializable]
internal abstract class ItemFlavor : Flavor, IGetKey
{
    protected ItemFlavor(Game game) : base(game) { }

    private Symbol _symbol;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ReadableFlavorGameConfiguration readableFlavorDefinition = new()
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
    public override Symbol Symbol => _symbol;
    
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        _symbol = Game.SingletonRepository.Get<Symbol>(SymbolName);
    }

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is used to bind the Symbol property during the bind phase.
    /// </summary>
    protected abstract string SymbolName { get; }
}
