internal class MagePhlogistonFolkSpell : ClassSpell
{
    private MagePhlogistonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellPhlogiston);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 7;
}