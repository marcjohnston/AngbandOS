[Serializable]
internal class MageResistTrueCorporealSpell : ClassSpell
{
    private MageResistTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellResistTrue);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 20;
}