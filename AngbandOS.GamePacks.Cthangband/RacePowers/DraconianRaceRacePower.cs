namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceBaseRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
}