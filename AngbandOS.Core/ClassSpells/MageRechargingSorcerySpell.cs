[Serializable]
internal class MageRechargingSorcerySpell : ClassSpell
{
    private MageRechargingSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellRecharging);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 9;
}