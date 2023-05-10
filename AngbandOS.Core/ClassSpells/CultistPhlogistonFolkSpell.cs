internal class CultistPhlogistonFolkSpell : ClassSpell
{
    private CultistPhlogistonFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellPhlogiston);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 7;
}