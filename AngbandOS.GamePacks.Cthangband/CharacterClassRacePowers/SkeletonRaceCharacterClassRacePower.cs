namespace AngbandOS.GamePacks.Cthangband;

public class SkeletonRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SkeletonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
}