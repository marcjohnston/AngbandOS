namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ImpRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.ImpRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 1;
}