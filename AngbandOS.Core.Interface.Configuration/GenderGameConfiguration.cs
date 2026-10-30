// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class GenderGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Title",
        Summary = "Display title for the gender (e.g., \"Male\", \"Female\").",
        DataType = "string")]
    public virtual string Title { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Winner",
        Summary = "Short title used when this gender is presented as the winner type.",
        DataType = "string")]
    /// <remarks>
    /// The comment indicates this may not currently be rendered; keep this value for potential UI usage.
    /// </remarks>
    public virtual string Winner { get; set; } // TODO ... this winner title to describe the type of winner is not rendered

    [ConfigurationMetadataAttribute(
        Title = "Can Be Randomly Selected",
        Summary = "Whether this gender may be chosen by the random-selection logic.",
        DataType = "bool")]
    public virtual bool CanBeRandomlySelected { get; set; } = true;

    [ConfigurationMetadataAttribute(
        Title = "Pronoun",
        Summary = "Pronoun to use when rendering messages referring to entities of this gender (default: \"it\").",
        DataType = "string")]
    /// <remarks>
    /// Localize or change to "he", "she", etc., as appropriate for the gender entry.
    /// </remarks>
    public virtual string Pronoun { get; set; } = "it";

    [ConfigurationMetadataAttribute(
        Title = "Possessive Adjective",
        Summary = "Possessive adjective to use when rendering messages (default: \"its\").",
        DataType = "string")]
    /// <remarks>
    /// Examples: "his", "her", "its". Used for natural-language assembly of messages.
    /// </remarks>
    public virtual string PossessiveAdjective { get; set; } = "its";
}
