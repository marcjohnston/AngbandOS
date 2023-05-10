internal class PriestPhlogistonFolkSpell : ClassSpell
{
    private PriestPhlogistonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellPhlogiston);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 8;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 7;
}