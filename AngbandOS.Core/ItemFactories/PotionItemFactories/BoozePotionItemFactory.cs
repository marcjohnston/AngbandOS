// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BoozePotionItemFactory : PotionItemFactory
{
    private BoozePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Booze";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Booze";
    public override int InitialTypeSpecificValue => 50;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // Confusion makes you confused and possibly other effects
        if (!(Game.HasConfusionResistance || Game.HasChaosResistance))
        {
            if (Game.ConfusedTimer.AddTimer(Game.RandomLessThan(20) + 15))
            {
                identified = true;
            }
            // 50% chance of having hallucinations
            if (Game.DieRoll(2) == 1)
            {
                if (Game.HallucinationsTimer.AddTimer(Game.RandomLessThan(150) + 150))
                {
                    identified = true;
                }
            }
            // 1 in 13 chance of blacking out and waking up somewhere else
            if (Game.DieRoll(13) == 1)
            {
                identified = true;
                // 1 in 3 chance of losing your memories after blacking out
                if (Game.DieRoll(3) == 1)
                {
                    Game.LoseAllInfo();
                }
                else
                {
                    Game.RunScript(nameof(DarkScript));
                }
                Game.RunScriptInt(nameof(TeleportSelfScript), 100);
                Game.RunScript(nameof(DarkScript));
                Game.MsgPrint("You wake up somewhere with a sore head...");
                Game.MsgPrint("You can't remember a thing, or how you got here!");
            }
        }
        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 2, y, x, 0, Game.SingletonRepository.Projectiles.Get(nameof(OldConfProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
