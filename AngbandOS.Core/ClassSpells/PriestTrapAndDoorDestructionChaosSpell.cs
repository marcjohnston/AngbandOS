[Serializable]
internal class PriestTrapAndDoorDestructionChaosSpell : ClassSpell
{
    private PriestTrapAndDoorDestructionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 24;
    public override int FirstCastExperience => 4;
}