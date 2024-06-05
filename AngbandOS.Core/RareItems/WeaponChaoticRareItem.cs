// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponChaoticRareItem : RareItem
{
    private WeaponChaoticRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool Chaotic => true;
    public override int Cost => 10000;
    public override string FriendlyName => "(Chaotic)";
    public override bool IgnoreAcid => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Rating => 28;
    public override bool ResChaos => true;
    }
