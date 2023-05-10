[Serializable]
internal class HighMageStinkingCloudDeathSpell : ClassSpell
{
    private HighMageStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 3;
}