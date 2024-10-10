// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Repositories;

[Serializable]
internal class ShopkeeperGoodCommentsRepository : StringListRepository
{
    public ShopkeeperGoodCommentsRepository(Game game) : base(game) { }

    /// <summary>
    /// Returns ShopkeeperGoodComments as the name of this string list repository.
    /// </summary>
    public override string Name => "ShopkeeperGoodComments";

    public override void Load(GameConfiguration configuration)
    {
        if (configuration.ShopkeeperGoodComments == null)
        {
            Add("Cool!",
                "You've made my day!",
                "The shopkeeper giggles.",
                "The shopkeeper laughs loudly."
                );
        }
        else
        {
            Add(configuration.ShopkeeperGoodComments);
        }
    }
}