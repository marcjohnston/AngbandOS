internal class RogueDetectEnchantmentSorcerySpell : ClassSpell
{
    private RogueDetectEnchantmentSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectEnchantment);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 10;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 5;
}