[Serializable]
internal class FanaticCallTheVoidChaosSpell : ClassSpell
{
    private FanaticCallTheVoidChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallTheVoid);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 100;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}