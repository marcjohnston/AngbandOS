namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GreatOneRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GreatOneRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 2;
}