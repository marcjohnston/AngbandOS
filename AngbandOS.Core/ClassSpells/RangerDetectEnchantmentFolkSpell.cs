[Serializable]
internal class RangerDetectEnchantmentFolkSpell : ClassSpell
{
    private RangerDetectEnchantmentFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectEnchantment);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}