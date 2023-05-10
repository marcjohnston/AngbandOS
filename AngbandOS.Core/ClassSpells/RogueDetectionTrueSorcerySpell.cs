[Serializable]
internal class RogueDetectionTrueSorcerySpell : ClassSpell
{
    private RogueDetectionTrueSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectionTrue);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 30;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 12;
}