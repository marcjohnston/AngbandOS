namespace AngbandOS.GamePacks.Cthangband;

public class ZombieRaceCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(ZombieRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
}