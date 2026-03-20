// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TeleportToAnyTownScript : Script, IScript
{
    private TeleportToAnyTownScript(Game game) : base(game) { }
    public void ExecuteScript()
    {
        var validTowns = new Dictionary<char, Town>();
        foreach (Town town in Game.SingletonRepository.Get<Town>())
        {
            if (town.Name != Game.CurTown.Name)
            {
                validTowns.Add(town.Char, town);
            }
        }
        Town? destination = Game.GetEscortDestination(validTowns);
        if (destination is not null)
        {
            Game.GoToTown(destination);
        }
    }
}
