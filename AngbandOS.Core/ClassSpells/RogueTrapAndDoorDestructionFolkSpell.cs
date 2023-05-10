[Serializable]
internal class RogueTrapAndDoorDestructionFolkSpell : ClassSpell
{
    private RogueTrapAndDoorDestructionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 7;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 7;
}