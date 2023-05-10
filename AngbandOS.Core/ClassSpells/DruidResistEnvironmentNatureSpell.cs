internal class DruidResistEnvironmentNatureSpell : ClassSpell
{
    private DruidResistEnvironmentNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistEnvironment);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}