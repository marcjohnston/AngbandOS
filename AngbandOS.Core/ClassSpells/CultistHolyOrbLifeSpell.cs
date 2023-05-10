internal class CultistHolyOrbLifeSpell : ClassSpell
{
    private CultistHolyOrbLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyOrb);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 26;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}