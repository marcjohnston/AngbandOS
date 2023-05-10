[Serializable]
internal class MageAttunementCorporealSpell : ClassSpell
{
    private MageAttunementCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellAttunement);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 30;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 160;
}