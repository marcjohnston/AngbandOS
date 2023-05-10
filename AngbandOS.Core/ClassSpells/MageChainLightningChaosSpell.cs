[Serializable]
internal class MageChainLightningChaosSpell : ClassSpell
{
    private MageChainLightningChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChainLightning);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 35;
}