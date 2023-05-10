[Serializable]
internal class MagePoisonBrandingDeathSpell : ClassSpell
{
    private MagePoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 75;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 30;
}