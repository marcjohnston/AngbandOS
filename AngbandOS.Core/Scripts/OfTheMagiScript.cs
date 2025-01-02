// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class OfTheMagiScript : Script, IReadScrollAndUseStaffScript
{
    private OfTheMagiScript(Game game) : base(game) { }

    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        bool isIdentified = false;
        if (Game.TryRestoringAbilityScore(AbilityEnum.Intelligence))
        {
            isIdentified = true;
        }
        if (Game.Mana.IntValue < Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
            Game.FractionalMana = 0;
            isIdentified = true;
            Game.MsgPrint("Your feel your head clear.");
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
