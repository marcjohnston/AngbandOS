namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRacePriestCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceHellFireOrHolyFireCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
}