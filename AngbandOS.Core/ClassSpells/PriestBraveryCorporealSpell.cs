internal class PriestBraveryCorporealSpell : ClassSpell
{
    private PriestBraveryCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBravery);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 1;
}