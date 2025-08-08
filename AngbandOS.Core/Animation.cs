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
internal sealed class Animation : IGetKey, IToJson
{
    private Game Game;
    public Animation(Game game, AnimationGameConfiguration animationGameConfiguration) 
    {
        Game = game;
        Key = animationGameConfiguration.Key ?? animationGameConfiguration.GetType().Name;
        AlternateColor = animationGameConfiguration.AlternateColor;
        Character = animationGameConfiguration.Character;
        Color = animationGameConfiguration.Color;
        Name = animationGameConfiguration.Name;
        Sequence = animationGameConfiguration.Sequence;
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

    public string Key { get; }

    public string GetKey => Key;

    public void Bind() { }

    public char Character { get; }
    public ColorEnum Color { get; }
    public string Name { get; }
    public ColorEnum AlternateColor { get; }
    public string Sequence { get; }

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
