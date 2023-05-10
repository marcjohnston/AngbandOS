internal class MonkAstralSpyingTarotSpell : ClassSpell
{
    private MonkAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 14;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}