internal class RangerAstralSpyingTarotSpell : ClassSpell
{
    private RangerAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 17;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}