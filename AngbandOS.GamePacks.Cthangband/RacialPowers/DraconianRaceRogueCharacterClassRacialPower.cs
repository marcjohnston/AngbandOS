namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceRogueCharacterClassRacialPower : RacialPowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceDarknessOrPoisonCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.RogueCharacterClass);
}