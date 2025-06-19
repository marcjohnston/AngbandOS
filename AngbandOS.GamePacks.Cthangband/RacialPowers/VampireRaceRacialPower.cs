namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class VampireRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(VampireRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
}