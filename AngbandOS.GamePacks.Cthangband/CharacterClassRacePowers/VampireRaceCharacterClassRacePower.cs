namespace AngbandOS.GamePacks.Cthangband;

public class VampireRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(VampireRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
}