internal class RangerTrapAndDoorDestructionFolkSpell : ClassSpell
{
    private RangerTrapAndDoorDestructionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 7;
}