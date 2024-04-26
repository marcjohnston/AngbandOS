// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class EatMagicActiveMutation : Mutation
{
    private EatMagicActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.SelectItem(out Item? oPtr, "Drain which item? ", false, true, true, Game.SingletonRepository.ItemFilters.Get(nameof(CanBeRechargedItemFilter))))
        {
            Game.MsgPrint("You have nothing appropriate to eat.");
            return;
        }
        if (!Game.CheckIfRacialPowerWorks(17, 1, Ability.Wisdom, 15))
        {
            return;
        }
        if (oPtr == null)
        {
            return;
        }

        int lev = oPtr.Factory.LevelNormallyFound;
        if (oPtr.Factory.ItemClass == Game.SingletonRepository.ItemClasses.Get(nameof(RodsItemClass)))
        {
            if (oPtr.TypeSpecificValue > 0)
            {
                Game.MsgPrint("You can't absorb energy from a discharged rod.");
            }
            else
            {
                Game.Mana.IntValue += 2 * lev;
                oPtr.TypeSpecificValue = 500;
            }
        }
        else
        { // Light? Wands? Staves, Food??
            if (oPtr.TypeSpecificValue > 0)
            {
                Game.Mana.IntValue += oPtr.TypeSpecificValue * lev;
                oPtr.TypeSpecificValue = 0;
            }
            else
            {
                Game.MsgPrint("There's no energy there to absorb!");
            }
            oPtr.IdentEmpty = true;
        }
        if (Game.Mana.IntValue > Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
        }
        base.Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 17 ? "eat magic        (unusable until level 17)" : "eat magic        (cost 1, WIS based)";
    }

    public override int Frequency => 1;
    public override string GainMessage => "Your magic items look delicious.";
    public override string HaveMessage => "You can consume magic energy for your own use.";
    public override string LoseMessage => "Your magic items no longer look delicious.";
}