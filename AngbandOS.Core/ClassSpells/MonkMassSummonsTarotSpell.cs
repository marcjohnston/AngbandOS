internal class MonkMassSummonsTarotSpell : ClassSpell
{
    private MonkMassSummonsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMassSummons);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 110;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}