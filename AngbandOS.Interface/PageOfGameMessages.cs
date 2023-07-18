namespace AngbandOS.Core.Interface;

public class PageOfGameMessages
{
    public IGameMessage[] GameMessages { get; }
    public int FirstIndex { get; }
    public int LastIndex { get; }
    public PageOfGameMessages(IGameMessage[] messages, int firstMessageIndex, int lastMessageIndex)
    {
        GameMessages = messages;
        FirstIndex = firstMessageIndex;
        LastIndex = lastMessageIndex;
    }
}
