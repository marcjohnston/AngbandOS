[Serializable]
internal class PaladinHellfireDeathSpell : ClassSpell
{
    private PaladinHellfireDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellHellfire);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 150;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}