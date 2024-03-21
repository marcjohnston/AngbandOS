// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.Animations;

/// <summary>
/// Represents an animation that occurs when a projectile is launched.
/// </summary>
[Serializable]
internal abstract class Animation : IGetKey
{
    protected Game Game;
    protected Animation(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        AnimationDefinition animationDefinition = new()
        {
            AlternateColor = AlternateColor,
            Character = Character,
            Color = Color,
            Key = Key,
            Name = Name,
            Sequence = Sequence
        };
        return JsonSerializer.Serialize<AnimationDefinition>(animationDefinition);
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    public abstract char Character { get; }
    public abstract ColorEnum Color { get; }
    public abstract string Name { get; }
    public abstract ColorEnum AlternateColor { get; }
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
                if (Game.PlayerHasLosBold(y[j], x[j]) && Game.PanelContains(y[j], x[j]))
                {
                    ColorEnum color = oddFrame ? Color : AlternateColor;
                    Game.PrintCharacterAtMapLocation(character, color, y[j], x[j]);
                    drawn = true;
                }
            }
            if (drawn)
            {
                Game.UpdateScreen();
                Game.Pause(msec);
            }
            oddFrame = !oddFrame;
        }
        if (drawn)
        {
            for (int j = 0; j < grids; j++)
            {
                if (Game.PlayerHasLosBold(y[j], x[j]) && Game.PanelContains(y[j], x[j]))
                {
                    Game.RedrawSingleLocation(y[j], x[j]);
                }
            }
            Game.UpdateScreen();
        }
    }
}
