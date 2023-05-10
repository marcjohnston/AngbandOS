[Serializable]
internal class HighMageLightningStormNatureSpell : ClassSpell
{
    private HighMageLightningStormNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningStorm);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 25;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 35;
}