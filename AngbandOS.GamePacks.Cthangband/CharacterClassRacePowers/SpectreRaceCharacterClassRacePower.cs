namespace AngbandOS.GamePacks.Cthangband;

public class SpectreRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpectreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpectreRace);
}