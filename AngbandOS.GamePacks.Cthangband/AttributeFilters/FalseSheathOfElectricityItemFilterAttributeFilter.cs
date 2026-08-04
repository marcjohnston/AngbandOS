namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class FalseSheathOfElectricityItemFilterAttributeFilter : AttributeFilterGameConfiguration
{
    public override (string AttributeKey, bool DesiredValue)[]? BitwiseOrAttributeFilterBindings => new (string, bool)[]
    {
        (nameof(ResElecAttribute), false),
        (nameof(CanProvideSheathOfElectricityAttribute), true),
    };
}