// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Flavours;

/// <summary>
/// Represents a single flavour for a group of items that participate in the IFlavour interface.
/// </summary>
[Serializable]
internal abstract class Flavour : IGetKey<string>
{
    protected SaveGame SaveGame;
    protected Flavour(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public virtual void Loaded() { }

    /// <summary>
    /// Returns the symbol to use for rendering.
    /// </summary>
    public abstract Symbol Symbol { get; }


    /// <summary>
    /// The color to use for the visual.
    /// </summary>
    public virtual ColourEnum Colour => ColourEnum.White;

    /// <summary>
    /// A unique identifier for the inscription.
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns true, if the flavour can be assigned; false, if the flavour shouldn't be assigned during the flavour assignments.  False will be returned for the
    /// apple juice, slime mold juice and water potions because they specify their flavours.
    /// </summary>
    public virtual bool CanBeAssigned => true;

    public override string ToString()
    {
        return Name;
    }
}
