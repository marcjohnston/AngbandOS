namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NibelungRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(NibelungRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
}