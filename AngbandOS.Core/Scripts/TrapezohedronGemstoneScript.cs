// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TrapezohedronGemstoneScript : Script, IActivateItemScript
{
    private TrapezohedronGemstoneScript(Game game) : base(game) { }

    public bool ExecuteActivateItemScript(Item item) // This is run by an item activation
    {
        Game.MsgPrint("The gemstone flashes bright red!");
        Game.RunScript(nameof(LightScript));
        Game.MsgPrint("The gemstone drains your vitality...");
        Game.TakeHit(base.Game.DiceRoll(3, 8), "the Gemstone 'Trapezohedron'");
        Game.DetectTraps();
        Game.DetectDoors();
        Game.DetectStairs();
        if (Game.GetCheck("Activate recall? "))
        {
            Game.RunScript(nameof(ToggleRecallScript));
        }
        return true;
    }
}
