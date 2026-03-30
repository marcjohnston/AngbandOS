namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpectreRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpectreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpectreRace);
}