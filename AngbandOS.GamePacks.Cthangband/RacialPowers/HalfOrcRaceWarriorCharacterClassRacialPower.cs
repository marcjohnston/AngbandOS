namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfOrcRaceWarriorCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfOrcRaceWarriorCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
}