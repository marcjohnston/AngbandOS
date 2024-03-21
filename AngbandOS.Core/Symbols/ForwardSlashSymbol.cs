[Serializable]
internal class ForwardSlashSymbol : Symbol
{
    private ForwardSlashSymbol(Game game) : base(game) { }
    public override char Character => '/';
    public override string Name => "A polearm (Axe/Pike/etc)";
}