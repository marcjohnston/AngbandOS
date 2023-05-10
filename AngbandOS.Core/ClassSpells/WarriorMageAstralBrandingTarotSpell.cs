internal class WarriorMageAstralBrandingTarotSpell : ClassSpell
{
    private WarriorMageAstralBrandingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralBranding);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}