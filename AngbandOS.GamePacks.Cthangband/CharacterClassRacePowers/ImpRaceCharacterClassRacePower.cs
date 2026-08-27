namespace AngbandOS.GamePacks.Cthangband;

public class ImpRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(ImpRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.ImpRace);
}