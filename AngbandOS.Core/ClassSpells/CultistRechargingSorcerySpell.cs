[Serializable]
internal class CultistRechargingSorcerySpell : ClassSpell
{
    private CultistRechargingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellRecharging);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 9;
}