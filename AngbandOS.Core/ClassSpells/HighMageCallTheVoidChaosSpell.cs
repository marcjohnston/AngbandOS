[Serializable]
internal class HighMageCallTheVoidChaosSpell : ClassSpell
{
    private HighMageCallTheVoidChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallTheVoid);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 90;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 250;
}