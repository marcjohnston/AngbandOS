[Serializable]
internal class MageElementalBrandingNatureSpell : ClassSpell
{
    private MageElementalBrandingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellElementalBranding);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 90;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}