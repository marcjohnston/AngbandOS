[Serializable]
internal class CultistBlizzardNatureSpell : ClassSpell
{
    private CultistBlizzardNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellBlizzard);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 29;
}