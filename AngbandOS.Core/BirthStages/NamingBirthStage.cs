﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class NamingBirthStage : BirthStage
{
    private NamingBirthStage(Game game) : base(game) { }
    public override BirthStage? Render()
    {
        if (string.IsNullOrEmpty(Game.PlayerName.StringValue))
        {
            Game.PlayerName.StringValue = Game.Race.CreateRandomName();
        }
        Game.InputPlayerName();
        return null;
    }
}
