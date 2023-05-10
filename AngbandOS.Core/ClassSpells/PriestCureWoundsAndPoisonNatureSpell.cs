internal class PriestCureWoundsAndPoisonNatureSpell : ClassSpell
{
    private PriestCureWoundsAndPoisonNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellCureWoundsAndPoison);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}