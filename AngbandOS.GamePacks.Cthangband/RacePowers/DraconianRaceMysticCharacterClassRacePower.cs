namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceMysticCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceConfusionOrPsiCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MysticCharacterClass);
}