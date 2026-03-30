// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class Vault : IGetKey, IToJson
{
    private Game Game { get; }
    public Vault(Game game, VaultGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        Color = gameConfiguration.Color;
        Name = gameConfiguration.Name;
        Category = gameConfiguration.Category;
        Height = gameConfiguration.Height;
        Rating = gameConfiguration.Rating;
        Text = gameConfiguration.Text;
        Width = gameConfiguration.Width;
    }

    public string Key { get; }

    public string GetKey => Key;
    public void Bind() { }

    public ColorEnum Color { get; } = ColorEnum.White;
    public string Name { get; }
    public int Category { get; }
    public int Height { get; }
    public int Rating { get; }
    public string Text { get; }
    public int Width { get; }

    public string ToJson()
    {
        VaultGameConfiguration vaultDefinition = new()
        {
            Key = Key,
            Color = Color,
            Name = Name,
            Category = Category,
            Height = Height,
            Rating = Rating,
            Text = Text,
            Width = Width
        };
        return JsonSerializer.Serialize(vaultDefinition, Game.GetJsonSerializerOptions());
    }
}
