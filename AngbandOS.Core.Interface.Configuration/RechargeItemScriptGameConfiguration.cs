using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Recharge Item Script",
    EntityNoun = "recharge item script")]
public class RechargeItemScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Turns Expression",
        Summary = "Specifies the expression used to determine the number of turns required to recharge an item.",
        DataType = "string")]
    public virtual string TurnsExpression { get; set; } = "60";

    [ConfigurationMetadata(
        Title = "Select Item Message",
        Summary = "Specifies the message displayed when selecting an item to recharge.",
        DataType = "string")]
    public virtual string SelectItemMessage { get; set; } = "Recharge which item? ";

    [ConfigurationMetadata(
        Title = "Non-Rechargeable Item Message",
        Summary = "Specifies the message displayed when the selected item cannot be recharged.",
        DataType = "string")]
    public virtual string NonRechargeableItemMessage { get; set; } = "That is not rechargeable!";

    [ConfigurationMetadata(
        Title = "Nothing Rechargeable Message",
        Summary = "Specifies the message displayed when no rechargeable items are available.",
        DataType = "string")]
    public virtual string NothingRechargeableMessage { get; set; } = "You have nothing to recharge.";
}
