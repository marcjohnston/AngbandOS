internal class DruidStoneSkinNatureSpell : ClassSpell
{
    private DruidStoneSkinNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellStoneSkin);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 120;
}