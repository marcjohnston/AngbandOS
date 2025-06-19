namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MiriNigriRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MiriNigriRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -1;
}