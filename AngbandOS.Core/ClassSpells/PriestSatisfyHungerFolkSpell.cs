[Serializable]
internal class PriestSatisfyHungerFolkSpell : ClassSpell
{
    private PriestSatisfyHungerFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSatisfyHunger);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 24;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}