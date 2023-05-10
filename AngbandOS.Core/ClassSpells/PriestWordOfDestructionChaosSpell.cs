[Serializable]
internal class PriestWordOfDestructionChaosSpell : ClassSpell
{
    private PriestWordOfDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWordOfDestruction);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 23;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 15;
}