[Serializable]
internal class RogueYellowSignSorcerySpell : ClassSpell
{
    private RogueYellowSignSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellYellowSign);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 40;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 100;
}