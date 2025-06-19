namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SpriteRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => -2;
}