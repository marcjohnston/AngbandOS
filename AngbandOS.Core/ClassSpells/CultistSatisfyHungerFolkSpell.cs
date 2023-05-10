[Serializable]
internal class CultistSatisfyHungerFolkSpell : ClassSpell
{
    private CultistSatisfyHungerFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellSatisfyHunger);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 12;
}