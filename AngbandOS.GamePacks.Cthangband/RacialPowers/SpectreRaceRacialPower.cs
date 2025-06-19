namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpectreRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SpectreRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SpectreRace);
}