﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

/// <summary>
/// Let the player scroll through previous messages
/// </summary>
[Serializable]
internal class MessagesStoreCommand : StoreCommand
{
    private MessagesStoreCommand(Game game) : base(game) { }
    public override char KeyChar => 'P';

    public override string Description => "";

    protected override string ExecuteScriptName => nameof(MessagesScript);
}
