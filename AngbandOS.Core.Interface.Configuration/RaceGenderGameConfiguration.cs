namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class RaceGenderGameConfiguration
{
    public virtual string RaceBindingKey { get; set; }
    public virtual string GenderBindingKey { get; set; }
    public virtual (string PhysicalAttributesBindingKey, int Weight)[] PhysicalAttributesWeightedRandomBindings { get; set; }
}