[Serializable]
internal class HighMageCureLightWoundsLifeSpell : ClassSpell
{
    private HighMageCureLightWoundsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCureLightWounds);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 4;
}