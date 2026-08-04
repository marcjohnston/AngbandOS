namespace AngbandOS.GamePacks.Cthangband;
public class WinnerConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(PropertiesEnum.IsWinnerBoolProperty), true, 0),
    };
}