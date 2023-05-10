[Serializable]
internal class HighMageDivineInterventionLifeSpell : ClassSpell
{
    private HighMageDivineInterventionLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDivineIntervention);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 60;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 100;
}