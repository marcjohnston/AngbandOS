[Serializable]
internal class PriestHellfireDeathSpell : ClassSpell
{
    private PriestHellfireDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHellfire);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 125;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}