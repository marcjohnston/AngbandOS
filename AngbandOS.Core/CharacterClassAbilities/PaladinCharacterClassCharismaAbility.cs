namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class PaladinCharacterClassCharismaAbility : CharacterClassAbility
{
    private PaladinCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(PaladinCharacterClass);
    public override int Bonus => 2;
}