[Serializable]
internal class CultistDetectEnchantmentFolkSpell : ClassSpell
{
    private CultistDetectEnchantmentFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectEnchantment);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 11;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}