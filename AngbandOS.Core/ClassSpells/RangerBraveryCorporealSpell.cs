internal class RangerBraveryCorporealSpell : ClassSpell
{
    private RangerBraveryCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBravery);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 2;
}