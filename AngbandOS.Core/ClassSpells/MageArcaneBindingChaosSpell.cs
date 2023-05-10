internal class MageArcaneBindingChaosSpell : ClassSpell
{
    private MageArcaneBindingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellArcaneBinding);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 14;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 35;
}