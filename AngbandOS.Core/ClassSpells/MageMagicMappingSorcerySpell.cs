[Serializable]
internal class MageMagicMappingSorcerySpell : ClassSpell
{
    private MageMagicMappingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellMagicMapping);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}