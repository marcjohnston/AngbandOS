namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class YeekRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(YeekRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.YeekRace);
}