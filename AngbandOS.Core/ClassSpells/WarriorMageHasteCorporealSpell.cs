internal class WarriorMageHasteCorporealSpell : ClassSpell
{
    private WarriorMageHasteCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHaste);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 18;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}