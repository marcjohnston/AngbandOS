[Serializable]
internal class MageCallTheVoidChaosSpell : ClassSpell
{
    private MageCallTheVoidChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallTheVoid);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 100;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}