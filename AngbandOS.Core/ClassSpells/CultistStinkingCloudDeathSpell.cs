[Serializable]
internal class CultistStinkingCloudDeathSpell : ClassSpell
{
    private CultistStinkingCloudDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellStinkingCloud);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 27;
    public override int FirstCastExperience => 3;
}