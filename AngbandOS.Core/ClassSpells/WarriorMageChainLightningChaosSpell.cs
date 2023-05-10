[Serializable]
internal class WarriorMageChainLightningChaosSpell : ClassSpell
{
    private WarriorMageChainLightningChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChainLightning);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 16;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 20;
}