[Serializable]
internal class WarriorMageEaglesVisionCorporealSpell : ClassSpell
{
    private WarriorMageEaglesVisionCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellEaglesVision);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}