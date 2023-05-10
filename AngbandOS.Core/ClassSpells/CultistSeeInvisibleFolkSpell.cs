internal class CultistSeeInvisibleFolkSpell : ClassSpell
{
    private CultistSeeInvisibleFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSeeInvisible);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 27;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 13;
}