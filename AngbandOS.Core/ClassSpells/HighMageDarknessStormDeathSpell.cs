[Serializable]
internal class HighMageDarknessStormDeathSpell : ClassSpell
{
    private HighMageDarknessStormDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarknessStorm);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 200;
}