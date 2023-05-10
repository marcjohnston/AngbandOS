[Serializable]
internal class RangerWonderChaosSpell : ClassSpell
{
    private RangerWonderChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWonder);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 23;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 5;
}