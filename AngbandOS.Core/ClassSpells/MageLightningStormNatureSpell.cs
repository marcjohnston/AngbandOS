[Serializable]
internal class MageLightningStormNatureSpell : ClassSpell
{
    private MageLightningStormNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningStorm);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 27;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 35;
}