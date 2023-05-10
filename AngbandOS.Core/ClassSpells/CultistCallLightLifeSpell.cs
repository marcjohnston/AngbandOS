internal class CultistCallLightLifeSpell : ClassSpell
{
    private CultistCallLightLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellCallLight);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}