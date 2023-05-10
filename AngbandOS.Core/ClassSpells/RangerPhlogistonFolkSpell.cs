[Serializable]
internal class RangerPhlogistonFolkSpell : ClassSpell
{
    private RangerPhlogistonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellPhlogiston);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 7;
}