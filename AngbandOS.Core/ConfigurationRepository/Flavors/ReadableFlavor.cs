// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavors;

/// <summary>
/// Represents a single flavor for a group of items that participate in the IFlavor interface.
/// </summary>
[Serializable]
internal abstract class ReadableFlavor : Flavor, IGetKey<string>
{
    protected ReadableFlavor(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    private Symbol _symbol;

    /// <summary>
    /// This property is bound from the SymbolName property during the binding phase.
    /// </summary>
    public override Symbol Symbol => _symbol;
    
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        _symbol = SaveGame.SingletonRepository.Symbols.Get(SymbolName);
    }

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is used to bind the Symbol property during the bind phase.
    /// </summary>
    protected abstract string SymbolName { get; }

    public override string ToString()
    {
        return Name;
    }
}
