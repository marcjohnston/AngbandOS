namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpectreRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpectreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpectreRace);
}