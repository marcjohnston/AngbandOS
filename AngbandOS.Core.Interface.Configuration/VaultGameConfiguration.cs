// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class VaultGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Description = "Specifies the display color of the vault.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty("string",
        Title = "Name",
        Description = "Specifies the name of the vault.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("int",
        Title = "Category",
        Description = "Specifies the category of the vault.")]
    public virtual int Category { get; set; }

    [ConfigurationProperty("int",
        Title = "Height",
        Description = "Specifies the height of the vault.")]
    public virtual int Height { get; set; }

    [ConfigurationProperty("int",
        Title = "Rating",
        Description = "Specifies the difficulty rating of the vault.")]
    public virtual int Rating { get; set; }

    [ConfigurationProperty("string",
        Title = "Text",
        Description = "Specifies the layout text of the vault.")]
    public virtual string Text { get; set; }

    [ConfigurationProperty("int",
        Title = "Width",
        Description = "Specifies the width of the vault.")]
    public virtual int Width { get; set; }
}
