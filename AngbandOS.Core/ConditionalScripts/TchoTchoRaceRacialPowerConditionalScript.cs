namespace AngbandOS.Core.ConditionalScripts;

[Serializable]
internal class TchoTchoRaceRacialPowerConditionalScript : ConditionalScript
{
    private TchoTchoRaceRacialPowerConditionalScript(Game game) : base(game) { }
    protected override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(TchoTchoRaceRacialPowerTest), true, 0)
    };
    protected override string[]? TrueScriptBindingKeys => new string[] { nameof(TchoTchoRacialPowerScript) };
}