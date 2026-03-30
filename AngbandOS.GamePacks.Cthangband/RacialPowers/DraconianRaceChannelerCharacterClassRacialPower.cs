namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceChannelerCharacterClassRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceManaOrDisenchantmentCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.ChannelerCharacterClass);
}