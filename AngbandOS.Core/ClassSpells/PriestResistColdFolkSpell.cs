internal class PriestResistColdFolkSpell : ClassSpell
{
    private PriestResistColdFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistCold);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 13;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}