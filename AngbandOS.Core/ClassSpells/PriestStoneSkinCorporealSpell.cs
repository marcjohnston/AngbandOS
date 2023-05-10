[Serializable]
internal class PriestStoneSkinCorporealSpell : ClassSpell
{
    private PriestStoneSkinCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellStoneSkin);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}