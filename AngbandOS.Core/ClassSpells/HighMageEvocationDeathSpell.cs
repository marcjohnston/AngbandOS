[Serializable]
internal class HighMageEvocationDeathSpell : ClassSpell
{
    private HighMageEvocationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEvocation);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 70;
}