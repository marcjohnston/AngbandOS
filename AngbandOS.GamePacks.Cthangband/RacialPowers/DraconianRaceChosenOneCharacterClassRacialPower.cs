namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceChosenOneCharacterClassRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
}