namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceCultistCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceConfusionOrChaosRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
}