[Serializable]
internal class PriestLightningBoltNatureSpell : ClassSpell
{
    private PriestLightningBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningBolt);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 6;
}