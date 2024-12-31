// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class OfTheMagiScript : Script, IIdentifiedAndUsedScript
{
    private OfTheMagiScript(Game game) : base(game) { }

    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        bool identified = false;
        if (Game.TryRestoringAbilityScore(AbilityEnum.Intelligence))
        {
            identified = true;
        }
        if (Game.Mana.IntValue < Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
            Game.FractionalMana = 0;
            identified = true;
            Game.MsgPrint("Your feel your head clear.");
        }
        return (identified, true);
    }
}
