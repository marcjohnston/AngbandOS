namespace AngbandOS.GamePacks.Cthangband;
public class PlayerTitleConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(PropertiesEnum.IsWizardBoolProperty), true, 0),
    };
}