[Serializable]
internal class MageResistAcidFolkSpell : ClassSpell
{
    private MageResistAcidFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistAcid);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}