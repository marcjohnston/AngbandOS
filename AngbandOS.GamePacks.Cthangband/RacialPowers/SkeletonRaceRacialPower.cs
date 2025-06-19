namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SkeletonRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(SkeletonRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.SkeletonRace);
}