[Serializable]
internal class RangerResistFireFolkSpell : ClassSpell
{
    private RangerResistFireFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistFire);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 16;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}