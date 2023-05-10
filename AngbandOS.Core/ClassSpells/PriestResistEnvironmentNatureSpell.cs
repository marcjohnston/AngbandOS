[Serializable]
internal class PriestResistEnvironmentNatureSpell : ClassSpell
{
    private PriestResistEnvironmentNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistEnvironment);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}