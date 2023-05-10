internal class HighMageChaosBrandingChaosSpell : ClassSpell
{
    private HighMageChaosBrandingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBranding);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 80;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 250;
}