namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RechargeItemScriptGameConfiguration
{
    public virtual string TurnsExpression { get; set; } = "60";
    public virtual string? Key { get; set; } = null;
    public virtual string SelectItemMessage { get; set; } = "Recharge which item? ";
    public virtual string NonRechargeableItemMessage { get; set; } = "That is not rechargeable!";
    public virtual string NothingRechargeableMessage { get; set; } = "You have nothing to recharge.";
}
