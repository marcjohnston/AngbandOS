internal class PriestResistFireFolkSpell : ClassSpell
{
    private PriestResistFireFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistFire);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 14;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}