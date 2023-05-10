internal class HighMageCureMediumWoundsFolkSpell : ClassSpell
{
    private HighMageCureMediumWoundsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellCureMediumWounds);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 11;
    public override int BaseFailure => 22;
    public override int FirstCastExperience => 6;
}