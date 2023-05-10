[Serializable]
internal class HighMageTerrorDeathSpell : ClassSpell
{
    private HighMageTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 10;
}