[Serializable]
internal class WarriorMageDetectionTrueSorcerySpell : ClassSpell
{
    private WarriorMageDetectionTrueSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectionTrue);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 15;
}