[Serializable]
internal class PriestStinkingCloudDeathSpell : ClassSpell
{
    private PriestStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 27;
    public override int FirstCastExperience => 4;
}