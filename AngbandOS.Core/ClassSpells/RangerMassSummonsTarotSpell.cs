internal class RangerMassSummonsTarotSpell : ClassSpell
{
    private RangerMassSummonsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMassSummons);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 120;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}