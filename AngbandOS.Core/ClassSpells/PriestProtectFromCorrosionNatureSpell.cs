internal class PriestProtectFromCorrosionNatureSpell : ClassSpell
{
    private PriestProtectFromCorrosionNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellProtectFromCorrosion);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 90;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}