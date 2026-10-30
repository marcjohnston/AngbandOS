// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ActivationGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Name",
        Summary = "The name of the activation.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Pre-Activation Message",
        Summary = "The message displayed before the activation occurs.",
        DataType = "string?")]
    public virtual string? PreActivationMessage { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "Value",
        Summary = "The value associated with the activation.",
        DataType = "int")]
    public virtual int Value { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Recharge Time Roll Expression",
        Summary = "The roll expression used to determine how long it takes for the activation to recharge.",
        DataType = "string")]
    public virtual string RechargeTimeRollExpression { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Activation Cancellable Script Item Binding Key",
        Summary = "The binding key of the script item that can cancel the activation.",
        DataType = "string")]
    public virtual string ActivationCancellableScriptItemBindingKey { get; set; }
}