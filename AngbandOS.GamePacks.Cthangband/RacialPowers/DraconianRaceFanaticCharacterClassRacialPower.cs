namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceFanaticCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceConfusionOrChaosRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
}