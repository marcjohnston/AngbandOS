[Serializable]
internal class CultistChaosBrandingChaosSpell : ClassSpell
{
    private CultistChaosBrandingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBranding);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 80;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 250;
}