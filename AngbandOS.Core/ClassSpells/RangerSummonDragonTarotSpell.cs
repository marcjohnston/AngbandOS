internal class RangerSummonDragonTarotSpell : ClassSpell
{
    private RangerSummonDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDragon);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 95;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}