internal class PriestChaosBrandingChaosSpell : ClassSpell
{
    private PriestChaosBrandingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBranding);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 90;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}