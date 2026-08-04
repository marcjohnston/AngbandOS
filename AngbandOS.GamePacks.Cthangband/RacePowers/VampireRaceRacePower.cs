namespace AngbandOS.GamePacks.Cthangband;

public class VampireRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(VampireRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
}