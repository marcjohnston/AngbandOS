[Serializable]
internal class RoguePhlogistonFolkSpell : ClassSpell
{
    private RoguePhlogistonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellPhlogiston);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 7;
}