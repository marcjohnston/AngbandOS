// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CastScript : Script, IScript, IRepeatableScript
{
    private CastScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the cast script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteRepeatableScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the cast script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.HasAntiMagic)
        {
            string whichMagicType = Game.BaseCharacterClass.MagicType;
            if (Game.BaseCharacterClass.ID == CharacterClassEnum.Mindcrafter || Game.BaseCharacterClass.ID == CharacterClassEnum.Mystic)
            {
                whichMagicType = "psychic talents";
            }
            Game.MsgPrint($"An anti-magic shell disrupts your {whichMagicType}!");
            Game.EnergyUse = 5;
        }
        else
        {
            Game.BaseCharacterClass.Cast();
        }
    }
}
