namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VampireRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(VampireRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
}