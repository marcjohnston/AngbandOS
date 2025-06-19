namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SpriteRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => -4;
}