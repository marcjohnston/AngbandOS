namespace AngbandOS.GamePacks.Cthangband;
public class ManaConditional : ConditionalGameConfiguration
{
    public override (string, bool, int)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(FunctionsEnum.UsesManaBoolFunction), true, 0)
    };
}