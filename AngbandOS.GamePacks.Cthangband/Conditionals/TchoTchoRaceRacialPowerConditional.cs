namespace AngbandOS.GamePacks.Cthangband;
public class TchoTchoRaceRacialPowerConditional : ConditionalGameConfiguration
{
    public override (string conditionalName, bool valueConditionalMustBe, int productOfSumsTerm)[] EnabledNames => new (string, bool, int)[]
    {
        (nameof(TchoTchoRaceRacialPowerTest), true, 0)
    };
}