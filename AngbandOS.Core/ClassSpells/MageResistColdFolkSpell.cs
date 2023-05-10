internal class MageResistColdFolkSpell : ClassSpell
{
    private MageResistColdFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistCold);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}