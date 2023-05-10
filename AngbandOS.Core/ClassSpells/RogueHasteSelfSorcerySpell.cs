[Serializable]
internal class RogueHasteSelfSorcerySpell : ClassSpell
{
    private RogueHasteSelfSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellHasteSelf);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 23;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 5;
}