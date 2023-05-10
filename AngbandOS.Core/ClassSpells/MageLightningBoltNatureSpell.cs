[Serializable]
internal class MageLightningBoltNatureSpell : ClassSpell
{
    private MageLightningBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningBolt);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 6;
}