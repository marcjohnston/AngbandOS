[Serializable]
internal class DruidElementalBrandingNatureSpell : ClassSpell
{
    private DruidElementalBrandingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellElementalBranding);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 80;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}