namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NibelungRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 0;
}