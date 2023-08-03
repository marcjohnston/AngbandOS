// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class OrbLightSourceItem : LightSourceItem
{
    public OrbLightSourceItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<OrbLightSourceItemFactory>()) { }
    /// <summary>
    /// Returns an intensity of light provided by the orb.  A value of 2 is returned, plus an additional 3
    /// if the orb is an artifact.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch()
    {
        return base.CalculateTorch() + 2;
    }
    public override bool IdentityCanBeSensed => true;
}