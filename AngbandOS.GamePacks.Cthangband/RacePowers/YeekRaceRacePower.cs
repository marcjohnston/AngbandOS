namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class YeekRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(YeekRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.YeekRace);
}