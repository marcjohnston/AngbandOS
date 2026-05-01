namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceMageCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
}