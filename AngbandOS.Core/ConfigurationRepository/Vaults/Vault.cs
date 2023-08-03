// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal abstract class Vault : IConfigurationRepository
{
    protected SaveGame SaveGame;
    protected Vault(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    /// <summary>
    /// Returns the symbol to use for rendering.
    /// </summary>
    public abstract Symbol Symbol { get; }

    public virtual ColourEnum Colour => ColourEnum.White;
    public abstract string Name { get; }
    public abstract int Category { get; }
    public abstract int Height { get; }
    public abstract int Rating { get; }
    public abstract string Text { get; }
    public abstract int Width { get; }
}
