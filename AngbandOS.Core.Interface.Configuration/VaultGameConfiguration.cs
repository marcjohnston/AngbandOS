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
    [ConfigurationProperty(
        Title = "Color",
        Summary = "Specifies the display color of the vault.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty(
        Title = "Name",
        Summary = "Specifies the name of the vault.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationProperty(
        Title = "Category",
        Summary = "Specifies the category of the vault.",
        DataType = "int")]
    public virtual int Category { get; set; }

    [ConfigurationProperty(
        Title = "Height",
        Summary = "Specifies the height of the vault.",
        DataType = "int")]
    public virtual int Height { get; set; }

    [ConfigurationProperty(
        Title = "Rating",
        Summary = "Specifies the difficulty rating of the vault.",
        DataType = "int")]
    public virtual int Rating { get; set; }

    [ConfigurationProperty(
        Title = "Text",
        Summary = "Specifies the layout text of the vault.",
        DataType = "string")]
    public virtual string Text { get; set; }

    [ConfigurationProperty(
        Title = "Width",
        Summary = "Specifies the width of the vault.",
        DataType = "int")]
    public virtual int Width { get; set; }
}
