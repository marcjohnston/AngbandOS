namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighElfRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HighElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 3;
}