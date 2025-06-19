namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CyclopsRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -3;
}