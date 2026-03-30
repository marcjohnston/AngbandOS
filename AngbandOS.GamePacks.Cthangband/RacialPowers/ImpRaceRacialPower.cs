namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ImpRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(ImpRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.ImpRace);
}