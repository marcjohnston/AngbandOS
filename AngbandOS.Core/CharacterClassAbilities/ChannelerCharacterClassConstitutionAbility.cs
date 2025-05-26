namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChannelerCharacterClassConstitutionAbility : CharacterClassAbility
{
    private ChannelerCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(ChannelerCharacterClass);
    public override int Bonus => -1;
}