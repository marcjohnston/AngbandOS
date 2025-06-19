namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceBaseRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
}