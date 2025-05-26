namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PaladinCharacterClassWisdomAbility : CharacterClassAbility
{
    private PaladinCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(PaladinCharacterClass);
    public override int Bonus => 1;
}