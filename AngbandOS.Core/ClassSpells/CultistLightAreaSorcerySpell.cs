internal class CultistLightAreaSorcerySpell : ClassSpell
{
    private CultistLightAreaSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellLightArea);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}