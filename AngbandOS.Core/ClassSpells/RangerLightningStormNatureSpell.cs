internal class RangerLightningStormNatureSpell : ClassSpell
{
    private RangerLightningStormNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningStorm);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 29;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 35;
}