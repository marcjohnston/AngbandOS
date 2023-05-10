internal class RangerBlinkFolkSpell : ClassSpell
{
    private RangerBlinkFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellBlink);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}