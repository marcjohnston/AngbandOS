namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceMonkCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceConfusionOrSoundCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MonkCharacterClass);
}