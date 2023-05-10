[Serializable]
internal class HighMageOrbOfEntropyDeathSpell : ClassSpell
{
    private HighMageOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 5;
}