namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MindFlayerRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(MindFlayerRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
}