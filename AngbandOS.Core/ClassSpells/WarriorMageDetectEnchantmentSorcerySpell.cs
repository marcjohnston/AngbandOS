internal class WarriorMageDetectEnchantmentSorcerySpell : ClassSpell
{
    private WarriorMageDetectEnchantmentSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectEnchantment);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}