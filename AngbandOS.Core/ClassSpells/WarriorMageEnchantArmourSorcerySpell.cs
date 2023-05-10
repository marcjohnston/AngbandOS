[Serializable]
internal class WarriorMageEnchantArmourSorcerySpell : ClassSpell
{
    private WarriorMageEnchantArmourSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellEnchantArmour);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}