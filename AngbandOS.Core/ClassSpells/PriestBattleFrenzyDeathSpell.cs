[Serializable]
internal class PriestBattleFrenzyDeathSpell : ClassSpell
{
    private PriestBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBattleFrenzy);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 33;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 33;
}