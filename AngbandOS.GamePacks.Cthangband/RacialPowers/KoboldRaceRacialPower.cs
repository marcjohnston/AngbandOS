namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KoboldRaceRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(KoboldRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
}