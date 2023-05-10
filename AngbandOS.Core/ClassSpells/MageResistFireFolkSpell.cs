internal class MageResistFireFolkSpell : ClassSpell
{
    private MageResistFireFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistFire);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}