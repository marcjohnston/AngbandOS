internal class PriestSeeInvisibleFolkSpell : ClassSpell
{
    private PriestSeeInvisibleFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSeeInvisible);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 13;
}