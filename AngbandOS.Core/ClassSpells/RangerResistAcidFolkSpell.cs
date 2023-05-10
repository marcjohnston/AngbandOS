[Serializable]
internal class RangerResistAcidFolkSpell : ClassSpell
{
    private RangerResistAcidFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistAcid);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 18;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}