// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class ChestItemFactory : ItemFactory
{
    public ChestItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(ChestsItemClass);
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Chests. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool IsContainer => true;

    public override bool IsStompable(Item item)
    {
        if (!item.IsKnown())
        {
            return false;
        }
        else if (item.ContainerIsOpen)
        {
            return Stompable[StompableType.Broken]; // Empty
        }
        else if (item.ContainerTraps == null)
        {
            return Stompable[StompableType.Average];
        }
        else
        {
            if (item.ContainerTraps.Length == 0)
            {
                return Stompable[StompableType.Good];
            }
            else
            {
                return Stompable[StompableType.Excellent];
            }
        }
    }

    public override int PackSort => 36;

    public override ColorEnum Color => ColorEnum.Grey;
}
