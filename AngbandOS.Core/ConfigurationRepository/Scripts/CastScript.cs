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
    private CastScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the cast script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the cast script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.HasAntiMagic)
        {
            string whichMagicType = SaveGame.BaseCharacterClass.SpellCastingType.MagicType;
            if (SaveGame.BaseCharacterClass.ID == CharacterClass.Mindcrafter || SaveGame.BaseCharacterClass.ID == CharacterClass.Mystic)
            {
                whichMagicType = "psychic talents";
            }
            SaveGame.MsgPrint($"An anti-magic shell disrupts your {whichMagicType}!");
            SaveGame.EnergyUse = 5;
        }
        else
        {
            SaveGame.BaseCharacterClass.SpellCastingType.Cast();
        }
    }
}
