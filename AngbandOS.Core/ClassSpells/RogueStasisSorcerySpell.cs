[Serializable]
internal class RogueStasisSorcerySpell : ClassSpell
{
    private RogueStasisSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellStasis);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 10;
}