internal class HighMageStoneToMudFolkSpell : ClassSpell
{
    private HighMageStoneToMudFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellStoneToMud);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 9;
}