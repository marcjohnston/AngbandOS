[Serializable]
internal class FanaticChaosBrandingChaosSpell : ClassSpell
{
    private FanaticChaosBrandingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBranding);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}