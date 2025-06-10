// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents an animation that occurs when a projectile is launched.
/// </summary>
[Serializable]
internal class Animation : IGetKey
{
    protected Game Game;
    public Animation(Game game, AnimationGameConfiguration animationGameConfiguration) 
    {
        Game = game;
        AlternateColor = animationGameConfiguration.AlternateColor;
        Character = animationGameConfiguration.Character;
        Color = animationGameConfiguration.Color;
        Key = animationGameConfiguration.Key ?? animationGameConfiguration.GetType().Name;
        Name = animationGameConfiguration.Name;
        Sequence = animationGameConfiguration.Sequence;
    }
    protected Animation(Game game)
    {
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        AnimationGameConfiguration animationDefinition = new()
        {
            AlternateColor = AlternateColor,
            Character = Character,
            Color = Color,
            Key = Key,
            Name = Name,
            Sequence = Sequence
        };
        return JsonSerializer.Serialize(animationDefinition, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;

    public virtual void Bind() { }

    public virtual char Character { get; }
    public virtual ColorEnum Color { get; }
    public virtual string Name { get; }
    public virtual ColorEnum AlternateColor { get; }
    public virtual string Sequence { get; }

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
                    Game.ConsoleView.PutCharAtMapLocation(character, color, y[j], x[j]);
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
                    Game.ConsoleView.RefreshMapLocation(y[j], x[j]);
                }
            }
            Game.UpdateScreen();
        }
    }
}
