internal class DruidEntangleNatureSpell : ClassSpell
{
    private DruidEntangleNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEntangle);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 10;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 7;
}