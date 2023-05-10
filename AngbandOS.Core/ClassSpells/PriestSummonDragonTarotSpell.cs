internal class PriestSummonDragonTarotSpell : ClassSpell
{
    private PriestSummonDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDragon);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 85;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}