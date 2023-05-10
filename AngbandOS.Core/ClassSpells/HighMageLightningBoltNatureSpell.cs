internal class HighMageLightningBoltNatureSpell : ClassSpell
{
    private HighMageLightningBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningBolt);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 6;
}