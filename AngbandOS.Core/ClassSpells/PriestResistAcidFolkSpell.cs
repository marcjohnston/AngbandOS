[Serializable]
internal class PriestResistAcidFolkSpell : ClassSpell
{
    private PriestResistAcidFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistAcid);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 16;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}