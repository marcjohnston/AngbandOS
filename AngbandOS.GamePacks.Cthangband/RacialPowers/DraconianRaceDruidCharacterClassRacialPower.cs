namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DraconianRaceDruidCharacterClassRacialPower : RacePowerGameConfiguration
{
    public override string ScriptBindingKey => nameof(DraconianRaceMissileOrExpolodeCharacterClassRacialPowerConditionalScript);
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.DruidCharacterClass);
}