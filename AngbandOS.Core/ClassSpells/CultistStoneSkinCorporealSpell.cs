[Serializable]
internal class CultistStoneSkinCorporealSpell : ClassSpell
{
    private CultistStoneSkinCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellStoneSkin);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}