[Serializable]
internal class CultistWordOfRecallCorporealSpell : ClassSpell
{
    private CultistWordOfRecallCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellWordOfRecall);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 19;
}