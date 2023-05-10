[Serializable]
internal class CultistChainLightningChaosSpell : ClassSpell
{
    private CultistChainLightningChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChainLightning);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 35;
}