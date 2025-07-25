﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class StayScript : UniversalScript, IGetKey
{
    private StayScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the stay script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Standing still takes a turn
        Game.EnergyUse = 100;

        // Periodically search if we're not actively in search mode
        if (Game.IsSearching || Game.SkillSearchFrequency >= 50 || Game.RandomLessThan(50 - Game.SkillSearchFrequency) == 0)
        {
            Game.RunScript(nameof(SearchScript));
        }

        // Pick up items if we should
        Game.StepOnGrid(false);

        // If we're in a shop doorway, enter the shop
        GridTile tile = Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue];
        if (tile.FeatureType.IsShop)
        {
            Game.Disturb(false);
            Game._artificialKeyBuffer += Game.SingletonRepository.Get<GameCommand>(nameof(EnterStoreGameCommand)).KeyChar;
        }
    }
}
