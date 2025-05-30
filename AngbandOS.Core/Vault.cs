// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal class Vault : IGetKey
{
    protected Game Game;
    public Vault(Game game, VaultGameConfiguration vaultGameConfiguration)
    {
        Key = vaultGameConfiguration.Key ?? vaultGameConfiguration.GetType().Name;
        Color = vaultGameConfiguration.Color;
        Name = vaultGameConfiguration.Name;
        Category = vaultGameConfiguration.Category;
        Height = vaultGameConfiguration.Height;
        Rating = vaultGameConfiguration.Rating;
        Text = vaultGameConfiguration.Text;
        Width = vaultGameConfiguration.Width;
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public virtual void Bind() { }

    public virtual ColorEnum Color { get; } = ColorEnum.White;
    public virtual string Name { get; }
    public virtual int Category { get; }
    public virtual int Height { get; }
    public virtual int Rating { get; }
    public virtual string Text { get; }
    public virtual int Width { get; }

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
