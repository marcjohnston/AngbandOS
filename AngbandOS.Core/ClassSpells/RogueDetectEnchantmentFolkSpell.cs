[Serializable]
internal class RogueDetectEnchantmentFolkSpell : ClassSpell
{
    private RogueDetectEnchantmentFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectEnchantment);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}