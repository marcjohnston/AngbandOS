[Serializable]
internal class HighMageManaBurstChaosSpell : ClassSpell
{
    private HighMageManaBurstChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellManaBurst);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 1;
}