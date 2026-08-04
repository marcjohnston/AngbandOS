namespace AngbandOS.GamePacks.Cthangband;

public class ZombieRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(ZombieRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
}