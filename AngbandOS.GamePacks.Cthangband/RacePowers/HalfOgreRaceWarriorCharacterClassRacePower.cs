namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOgreRaceWarriorCharacterClassRacePower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOgreRaceWarriorCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
}