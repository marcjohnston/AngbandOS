[Serializable]
internal class MageDetectionTrueSorcerySpell : ClassSpell
{
    private MageDetectionTrueSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectionTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 20;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}