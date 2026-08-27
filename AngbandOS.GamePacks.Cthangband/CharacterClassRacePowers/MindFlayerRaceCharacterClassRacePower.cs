namespace AngbandOS.GamePacks.Cthangband;

public class MindFlayerRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(MindFlayerRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
}