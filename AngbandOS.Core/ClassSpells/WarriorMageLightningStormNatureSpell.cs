internal class WarriorMageLightningStormNatureSpell : ClassSpell
{
    private WarriorMageLightningStormNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningStorm);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 35;
}