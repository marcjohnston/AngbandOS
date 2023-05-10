[Serializable]
internal class HighMageIdentifyTrueSorcerySpell : ClassSpell
{
    private HighMageIdentifyTrueSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellIdentifyTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 20;
}