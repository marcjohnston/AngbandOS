internal class HighMageWordOfDestructionChaosSpell : ClassSpell
{
    private HighMageWordOfDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWordOfDestruction);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 17;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}