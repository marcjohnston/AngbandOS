// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfInfravisionRareItem : RareItem
{
    private HatOfInfravisionRareItem(Game game) : base(game) { } // This object is a singleton.
    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Hat of Infravision";
    public override int Cost => 500;
    public override string FriendlyName => "of Infravision";
    public override bool HideType => true;
    public override bool Infra => true;
    public override int Level => 0;
    public override int MaxPval => 5;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override int Rarity => 0;
    public override int Rating => 11;
    public override int Slot => 33;
}