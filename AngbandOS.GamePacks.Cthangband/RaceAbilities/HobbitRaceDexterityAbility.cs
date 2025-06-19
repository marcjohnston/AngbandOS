namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HobbitRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 3;
}