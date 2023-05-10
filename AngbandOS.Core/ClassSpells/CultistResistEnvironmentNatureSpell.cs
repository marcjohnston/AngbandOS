internal class CultistResistEnvironmentNatureSpell : ClassSpell
{
    private CultistResistEnvironmentNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellResistEnvironment);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}