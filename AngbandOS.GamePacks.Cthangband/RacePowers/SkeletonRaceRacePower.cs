namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SkeletonRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SkeletonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
}