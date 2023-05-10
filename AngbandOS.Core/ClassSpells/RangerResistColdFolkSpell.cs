[Serializable]
internal class RangerResistColdFolkSpell : ClassSpell
{
    private RangerResistColdFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistCold);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}