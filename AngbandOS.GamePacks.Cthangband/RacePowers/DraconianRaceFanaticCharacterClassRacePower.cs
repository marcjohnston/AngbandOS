namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceFanaticCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceConfusionOrChaosRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.FanaticCharacterClass);
}