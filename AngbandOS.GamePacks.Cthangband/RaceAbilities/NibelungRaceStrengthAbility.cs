namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NibelungRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 1;
}