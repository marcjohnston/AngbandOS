namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SpriteRaceIntelligenceAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.IntelligenceAbility);
    public override int Bonus => 3;
}