namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HalfTrollRaceWarriorCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(HalfTrollRaceWarriorCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.WarriorCharacterClass);
}