[Serializable]
internal class RogueAstralLoreTarotSpell : ClassSpell
{
    private RogueAstralLoreTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralLore);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 65;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}