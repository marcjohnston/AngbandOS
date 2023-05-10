[Serializable]
internal class HighMageClairvoyanceSorcerySpell : ClassSpell
{
    private HighMageClairvoyanceSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellClairvoyance);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 120;
}