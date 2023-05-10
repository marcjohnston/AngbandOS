[Serializable]
internal class HighMageDisintegrateChaosSpell : ClassSpell
{
    private HighMageDisintegrateChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDisintegrate);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 100;
}