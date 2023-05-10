[Serializable]
internal class HighMageDetectCreaturesNatureSpell : ClassSpell
{
    private HighMageDetectCreaturesNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDetectCreatures);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 4;
}