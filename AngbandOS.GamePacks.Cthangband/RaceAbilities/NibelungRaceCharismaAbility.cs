namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NibelungRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -4;
}