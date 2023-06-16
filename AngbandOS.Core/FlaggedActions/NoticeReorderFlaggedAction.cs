namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class NoticeReorderFlaggedAction : FlaggedAction
{
    public NoticeReorderFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        bool itemsWereReordered = SaveGame.SortPack();
        if (itemsWereReordered)
        {
            SaveGame.MsgPrint("You reorder some items in your pack.");
        }
    }
}
