// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Vampire50Script : Script, IDirectionalActivationScript
{
    private Vampire50Script(Game game) : base(game) { }

    public UsedResult ExecuteDirectionalActivationScript(Item item, int direction) // This is run by an item activation
    {
        for (int i = 0; i < 3; i++)
        {
            if (Game.RunIdentifiedScript(nameof(OldDrainLife50ProjectileScript)))
            {
                Game.RestoreHealth(50);
            }
        }
        return new UsedResult(true);
    }
}
