namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class KoboldRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(KoboldRaceRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
}