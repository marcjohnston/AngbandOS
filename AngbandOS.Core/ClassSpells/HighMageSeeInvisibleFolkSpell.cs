[Serializable]
internal class HighMageSeeInvisibleFolkSpell : ClassSpell
{
    private HighMageSeeInvisibleFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSeeInvisible);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 18;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 13;
}