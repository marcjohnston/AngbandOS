// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal abstract class Vault
{
    protected SaveGame SaveGame;
    protected Vault(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract char Character { get; }
    public virtual Colour Colour => Colour.White;
    public abstract string Name { get; }
    public abstract int Category { get; }
    public abstract int Height { get; }
    public abstract int Rating { get; }
    public abstract string Text { get; }
    public abstract int Width { get; }
}
