[Serializable]
internal class RangerBattleFrenzyDeathSpell : ClassSpell
{
    private RangerBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBattleFrenzy);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 39;
    public override int BaseFailure => 76;
    public override int FirstCastExperience => 50;
}