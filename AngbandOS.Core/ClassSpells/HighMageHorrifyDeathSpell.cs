[Serializable]
internal class HighMageHorrifyDeathSpell : ClassSpell
{
    private HighMageHorrifyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHorrify);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}