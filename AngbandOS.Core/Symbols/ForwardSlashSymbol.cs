[Serializable]
internal class ForwardSlashSymbol : Symbol
{
    private ForwardSlashSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '/';
    public override string Name => "A polearm (Axe/Pike/etc)";
}