internal class PriestRestorationLifeSpell : ClassSpell
{
    private PriestRestorationLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRestoration);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 70;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}