internal class CultistLightningStormNatureSpell : ClassSpell
{
    private CultistLightningStormNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningStorm);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 35;
}