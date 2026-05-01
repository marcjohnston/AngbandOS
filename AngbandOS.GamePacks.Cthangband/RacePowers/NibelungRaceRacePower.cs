namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NibelungRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(NibelungRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
}