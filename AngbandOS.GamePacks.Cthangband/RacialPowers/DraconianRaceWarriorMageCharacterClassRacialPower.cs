namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceWarriorMageCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorMageCharacterClass);
}