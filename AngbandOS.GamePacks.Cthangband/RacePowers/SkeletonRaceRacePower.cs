namespace AngbandOS.GamePacks.Cthangband;

public class SkeletonRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SkeletonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
}