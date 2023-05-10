internal class FanaticTrapAndDoorDestructionChaosSpell : ClassSpell
{
    private FanaticTrapAndDoorDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 22;
    public override int FirstCastExperience => 4;
}