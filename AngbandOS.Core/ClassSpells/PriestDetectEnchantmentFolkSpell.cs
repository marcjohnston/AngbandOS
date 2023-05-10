[Serializable]
internal class PriestDetectEnchantmentFolkSpell : ClassSpell
{
    private PriestDetectEnchantmentFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectEnchantment);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}