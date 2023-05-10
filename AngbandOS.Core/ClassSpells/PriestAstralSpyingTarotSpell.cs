internal class PriestAstralSpyingTarotSpell : ClassSpell
{
    private PriestAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 14;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}