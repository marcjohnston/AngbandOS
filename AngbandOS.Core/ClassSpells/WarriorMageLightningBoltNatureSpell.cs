[Serializable]
internal class WarriorMageLightningBoltNatureSpell : ClassSpell
{
    private WarriorMageLightningBoltNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellLightningBolt);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 6;
}