namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceWarriorCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
}