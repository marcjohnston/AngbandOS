[Serializable]
internal class RogueEnchantArmourSorcerySpell : ClassSpell
{
    private RogueEnchantArmourSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellEnchantArmour);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}