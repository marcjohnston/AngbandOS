internal class CultistBlinkFolkSpell : ClassSpell
{
    private CultistBlinkFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellBlink);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}