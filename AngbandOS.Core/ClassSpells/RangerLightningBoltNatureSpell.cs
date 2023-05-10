[Serializable]
internal class RangerLightningBoltNatureSpell : ClassSpell
{
    private RangerLightningBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningBolt);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 7;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 3;
}