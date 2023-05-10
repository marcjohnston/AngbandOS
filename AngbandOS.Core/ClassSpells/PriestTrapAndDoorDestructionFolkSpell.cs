internal class PriestTrapAndDoorDestructionFolkSpell : ClassSpell
{
    private PriestTrapAndDoorDestructionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 7;
}