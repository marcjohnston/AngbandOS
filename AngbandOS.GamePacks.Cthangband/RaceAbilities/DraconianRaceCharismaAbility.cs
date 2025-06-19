namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DraconianRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -3;
}