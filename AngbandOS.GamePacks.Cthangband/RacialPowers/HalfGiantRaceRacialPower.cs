namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfGiantRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfGiantRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
}