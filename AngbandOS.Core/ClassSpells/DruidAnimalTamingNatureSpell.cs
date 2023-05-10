internal class DruidAnimalTamingNatureSpell : ClassSpell
{
    private DruidAnimalTamingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalTaming);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}