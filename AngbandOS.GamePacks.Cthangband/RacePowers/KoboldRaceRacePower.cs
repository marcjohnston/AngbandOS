namespace AngbandOS.GamePacks.Cthangband;

public class KoboldRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(KoboldRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
}