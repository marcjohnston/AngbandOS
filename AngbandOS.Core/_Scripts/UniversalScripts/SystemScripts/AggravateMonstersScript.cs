// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AggravateMonstersScript : UniversalScript, IGetKey
{
    private AggravateMonstersScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override bool IdentifiesItem => true;
    public override bool UsesItem => true;
    public override void ExecuteScript()
    {
        Game.MsgPrint("There is a high pitched humming noise.");
        Game.AggravateMonsters();
    }
}

