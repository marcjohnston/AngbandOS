internal class FanaticArcaneBindingChaosSpell : ClassSpell
{
    private FanaticArcaneBindingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellArcaneBinding);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 35;
}