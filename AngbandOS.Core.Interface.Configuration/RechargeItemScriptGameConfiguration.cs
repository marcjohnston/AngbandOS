using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RechargeItemScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Turns Expression",
        Description = "Specifies the expression used to determine the number of turns required to recharge an item.")]
    public virtual string TurnsExpression { get; set; } = "60";

    [ConfigurationProperty("string",
        Title = "Select Item Message",
        Description = "Specifies the message displayed when selecting an item to recharge.")]
    public virtual string SelectItemMessage { get; set; } = "Recharge which item? ";

    [ConfigurationProperty("string",
        Title = "Non-Rechargeable Item Message",
        Description = "Specifies the message displayed when the selected item cannot be recharged.")]
    public virtual string NonRechargeableItemMessage { get; set; } = "That is not rechargeable!";

    [ConfigurationProperty("string",
        Title = "Nothing Rechargeable Message",
        Description = "Specifies the message displayed when no rechargeable items are available.")]
    public virtual string NothingRechargeableMessage { get; set; } = "You have nothing to recharge.";
}
