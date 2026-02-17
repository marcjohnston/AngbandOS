// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ItemIdentificationGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings { get; set; } = null;
    public virtual (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings { get; set; } = null;
    public virtual (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings { get; set; } = null;
    public virtual bool? ActivationAttributeNonNull { get; set; } = null;
    public virtual bool? ArtifactBiasAttributeNonNull { get; set; } = null;
    public virtual string[]? InterpolationExpressionAttributeNames { get; set; } = null;
    public virtual string[] EffectDescription { get; set; }
}
