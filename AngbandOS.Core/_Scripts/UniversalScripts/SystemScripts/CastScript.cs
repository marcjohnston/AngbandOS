// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CastScript : UniversalScript, IGetKey
{
    private CastScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    /// <summary>
    /// Executes the cast script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        if (Game.HasAntiMagic)
        {
            string whichMagicType = Game.BaseCharacterClass.MagicType;
            Game.MsgPrint($"An anti-magic shell disrupts your {whichMagicType}!");
            Game.EnergyUse = 5;
        }
        else
        {
            Game.BaseCharacterClass.Cast();
        }
    }
}
