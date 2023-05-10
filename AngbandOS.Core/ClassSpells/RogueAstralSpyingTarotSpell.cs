[Serializable]
internal class RogueAstralSpyingTarotSpell : ClassSpell
{
    private RogueAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}