namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class PlayerTitleProductOfSumsConditional : ProductOfSumsConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(PropertiesEnum.IsWizardBoolProperty), true, 0),
    };
}