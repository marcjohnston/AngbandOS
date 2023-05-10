internal class FanaticWordOfDestructionChaosSpell : ClassSpell
{
    private FanaticWordOfDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWordOfDestruction);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 26;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}