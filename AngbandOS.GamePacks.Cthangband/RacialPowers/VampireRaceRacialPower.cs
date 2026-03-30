namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VampireRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(VampireRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
}