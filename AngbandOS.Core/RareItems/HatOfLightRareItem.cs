// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfLightRareItem : RareItem
{
    private HatOfLightRareItem(Game game) : base(game) { } // This object is a singleton.
    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Hat of Light";
    public override int Cost => 500;
    public override string FriendlyName => "of Light";
    public override int Level => 0;
    public override bool Lightsource => true;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override int Rarity => 0;
    public override int Rating => 6;
    public override bool ResLight => true;
    public override int Slot => 33;
}