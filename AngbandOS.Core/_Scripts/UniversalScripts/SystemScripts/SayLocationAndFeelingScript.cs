﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SayLocationAndFeelingScript : UniversalScript, IGetKey
{
    private SayLocationAndFeelingScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the say location and feeling script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        if (Game.CurrentDepth <= 0)
        {
            // If we need to say where we are, do so
            if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Town != null)
            {
                Game.MsgPrint($"You are in {Game.CurTown.Name}.");
            }
            else if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon != null)
            {
                Game.MsgPrint($"You are outside {Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Name}.");
            }
            else
            {
                Game.MsgPrint("You are wandering around outside.");
            }
        }
        else
        {
            Game.MsgPrint($"You are in {Game.CurDungeon.Name}.");
            if (Game.IsQuest(Game.CurrentDepth))
            {
                Game.PrintQuestMessage();
            }
        }
        Game.RunScript(nameof(SayFeelingScript));
    }
}
