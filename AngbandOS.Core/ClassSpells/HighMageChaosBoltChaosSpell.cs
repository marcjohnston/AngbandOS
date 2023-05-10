internal class HighMageChaosBoltChaosSpell : ClassSpell
{
    private HighMageChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 10;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 9;
}