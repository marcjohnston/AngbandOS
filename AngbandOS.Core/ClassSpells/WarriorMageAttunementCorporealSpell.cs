[Serializable]
internal class WarriorMageAttunementCorporealSpell : ClassSpell
{
    private WarriorMageAttunementCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellAttunement);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 35;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 160;
}