[Serializable]
internal class HighMageTheFoolTarotSpell : ClassSpell
{
    private HighMageTheFoolTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTheFool);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 20;
}