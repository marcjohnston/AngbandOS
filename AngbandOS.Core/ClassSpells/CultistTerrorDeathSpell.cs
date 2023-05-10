internal class CultistTerrorDeathSpell : ClassSpell
{
    private CultistTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 21;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 10;
}