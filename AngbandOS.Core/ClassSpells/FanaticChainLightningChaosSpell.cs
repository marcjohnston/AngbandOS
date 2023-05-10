[Serializable]
internal class FanaticChainLightningChaosSpell : ClassSpell
{
    private FanaticChainLightningChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChainLightning);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 20;
}