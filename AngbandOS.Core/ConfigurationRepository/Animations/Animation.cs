// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Animations;

/// <summary>
/// Represents an animation that occurs when a projectile is launched.
/// </summary>
[Serializable]
internal abstract class Animation : IConfigurationItem
{
    protected SaveGame SaveGame;
    protected Animation(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract char Character { get; }
    public abstract ColourEnum Colour { get; }
    public abstract string Name { get; }
    public abstract ColourEnum AlternateColour { get; }
    public abstract string Sequence { get; }

    public void Animate(int[] y, int[] x)
    {
        int msec = Constants.DelayFactorInMilliseconds;
        int grids = x.Length;
        bool drawn = false;
        bool oddFrame = true;
        foreach (char character in Sequence)
        {
            for (int j = 0; j < grids; j++)
            {
                if (SaveGame.PlayerHasLosBold(y[j], x[j]) && SaveGame.PanelContains(y[j], x[j]))
                {
                    ColourEnum colour = oddFrame ? Colour : AlternateColour;
                    SaveGame.PrintCharacterAtMapLocation(character, colour, y[j], x[j]);
                    drawn = true;
                }
            }
            if (drawn)
            {
                SaveGame.UpdateScreen();
                SaveGame.Pause(msec);
            }
            oddFrame = !oddFrame;
        }
        if (drawn)
        {
            for (int j = 0; j < grids; j++)
            {
                if (SaveGame.PlayerHasLosBold(y[j], x[j]) && SaveGame.PanelContains(y[j], x[j]))
                {
                    SaveGame.RedrawSingleLocation(y[j], x[j]);
                }
            }
            SaveGame.UpdateScreen();
        }
    }
}
