[Serializable]
internal class HighMageCarnageDeathSpell : ClassSpell
{
    private HighMageCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellCarnage);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 25;
}