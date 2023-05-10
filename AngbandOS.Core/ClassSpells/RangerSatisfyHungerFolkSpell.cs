[Serializable]
internal class RangerSatisfyHungerFolkSpell : ClassSpell
{
    private RangerSatisfyHungerFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSatisfyHunger);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 27;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}