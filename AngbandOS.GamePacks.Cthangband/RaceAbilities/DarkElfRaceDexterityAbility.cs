namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DarkElfRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 2;
}