[Serializable]
internal class CultistResistAcidFolkSpell : ClassSpell
{
    private CultistResistAcidFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistAcid);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 17;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}