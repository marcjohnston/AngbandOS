[Serializable]
internal class HighMageResistEnvironmentNatureSpell : ClassSpell
{
    private HighMageResistEnvironmentNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistEnvironment);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}