internal class CultistMagicMappingSorcerySpell : ClassSpell
{
    private CultistMagicMappingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellMagicMapping);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 9;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}