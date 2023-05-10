internal class PriestBlinkFolkSpell : ClassSpell
{
    private PriestBlinkFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellBlink);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}