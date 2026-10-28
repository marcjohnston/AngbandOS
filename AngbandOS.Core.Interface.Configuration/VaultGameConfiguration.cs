// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Vault",
    EntityNoun = "vault")]
public class VaultGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Color",
        Summary = "Specifies the display color of the vault.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationMetadata(
        Title = "Name",
        Summary = "Specifies the name of the vault.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Category",
        Summary = "Specifies the category of the vault.",
        DataType = "int")]
    public virtual int Category { get; set; }

    [ConfigurationMetadata(
        Title = "Height",
        Summary = "Specifies the height of the vault.",
        DataType = "int")]
    public virtual int Height { get; set; }

    [ConfigurationMetadata(
        Title = "Rating",
        Summary = "Specifies the difficulty rating of the vault.",
        DataType = "int")]
    public virtual int Rating { get; set; }

    [ConfigurationMetadata(
        Title = "Text",
        Summary = "Specifies the layout text of the vault.",
        DataType = "string")]
    public virtual string Text { get; set; }

    [ConfigurationMetadata(
        Title = "Width",
        Summary = "Specifies the width of the vault.",
        DataType = "int")]
    public virtual int Width { get; set; }
}
