// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ConditionalGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Enabled Names",
        Summary = "The conditional names and required values used to determine whether configuration conditions are enabled.",
        DataType = "(string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[]")]
    [ConfigurationTupleItemAttribute(
        "conditionalName",
        Title = "Conditional Name")]
    [ConfigurationTupleItemAttribute(
        "valueConditionalMustBe",
        Title = "Value Conditional Must Be")]
    [ConfigurationTupleItemAttribute(
        "productOfSumsTerm",
        Title = "Product Of Sums Term")]
    public virtual (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames { get; set; }
}
