[Serializable]
internal class PriestChainLightningChaosSpell : ClassSpell
{
    private PriestChainLightningChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChainLightning);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 17;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 20;
}