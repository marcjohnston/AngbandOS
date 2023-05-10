internal class PriestCallLightLifeSpell : ClassSpell
{
    private PriestCallLightLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCallLight);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 27;
    public override int FirstCastExperience => 2;
}