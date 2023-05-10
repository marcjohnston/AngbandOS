internal class MonkTarotDrawTarotSpell : ClassSpell
{
    private MonkTarotDrawTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTarotDraw);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}