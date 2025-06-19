namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ZombieRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(ZombieRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
}