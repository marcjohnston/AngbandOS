internal class PriestSummonAncientDragonTarotSpell : ClassSpell
{
    private PriestSummonAncientDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAncientDragon);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 120;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}