[Serializable]
internal class PriestLightningStormNatureSpell : ClassSpell
{
    private PriestLightningStormNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningStorm);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 30;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 29;
}