[Serializable]
internal class RangerStoneSkinCorporealSpell : ClassSpell
{
    private RangerStoneSkinCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellStoneSkin);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 17;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}