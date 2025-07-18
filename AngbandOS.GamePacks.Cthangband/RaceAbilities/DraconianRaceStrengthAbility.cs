namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DraconianRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 2;
}