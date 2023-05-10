[Serializable]
internal class HighMageHasteSelfSorcerySpell : ClassSpell
{
    private HighMageHasteSelfSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellHasteSelf);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 8;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}