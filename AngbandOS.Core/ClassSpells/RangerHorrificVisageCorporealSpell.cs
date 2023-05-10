[Serializable]
internal class RangerHorrificVisageCorporealSpell : ClassSpell
{
    private RangerHorrificVisageCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHorrificVisage);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 20;
}