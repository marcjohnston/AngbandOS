// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Properties;

[Serializable]
internal class GameMessageProperty : Property, IGameSerialize
{
    private GameMessageProperty(Game game) : base(game) { }
    public Queue<string?> MessageQueue = new Queue<string?>();

    /// <summary>
    /// Returns the current message.
    /// </summary>
    public string StringValue { get; set; } = "";

    public override string ToString()
    {
        return StringValue;
    }

    public void Add(params string?[] messages)
    {
        // There is no ability to enqueue multiple items.
        foreach (string? message in messages)
        {
            MessageQueue.Enqueue(message);
            SetChangedFlag();
        }
    }
    public override void Bind(RestoreGameState? restoreGameState)
    {
        base.Bind(restoreGameState);
        if (restoreGameState is not null)
        {
            foreach (string message in restoreGameState.GetQueueStrings(nameof(MessageQueue)))
            {
                MessageQueue.Enqueue(message);
            }
        }
    }

    public override DictionaryGameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(base.Serialize(saveGameState),
            (nameof(MessageQueue), new QueueOfStringGameStateBag(MessageQueue.ToArray()))
        );
    }
}
