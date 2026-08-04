namespace AngbandOS.GamePacks.Cthangband;

public class MindFlayerRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(MindFlayerRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
}