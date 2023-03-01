namespace AngbandOS.Core.ConsoleElements
{
    internal class ConsoleGrid : ConsoleElement
    {
        private List<ConsoleCard> cardList = new List<ConsoleCard>();
        public override int Width => throw new NotImplementedException();

        public override int Height => throw new NotImplementedException();
        public void AddCard(ConsoleCard card)
        {
            cardList.Add(card);
        }

        public int VerticalMargin = 1;
        public int HorizontalMargin = 1;

        public override void Render(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
        {
            ConsoleLocation topLeft = containerWindow.TopLeft;
            int maxGroupHeight = 0;
            foreach (ConsoleCard card in cardList)
            {
                // Determine if we need to wrap for the next card.  Wrapping is disabled when positioned on the left of the container window.
                if (topLeft.X > containerWindow.Left && topLeft.X + card.Width > 79)
                {
                    // Perform wrapping now.
                    topLeft = new ConsoleLocation(containerWindow.Left, topLeft.Y + maxGroupHeight + HorizontalMargin);
                }

                // Render the card.
                card.Render(saveGame, new ConsoleWindow(topLeft, containerWindow.BottomRight), parentAlignment);

                // Track the bottom margin of the cards for wrapping.
                if (card.Height > maxGroupHeight)
                {
                    maxGroupHeight = card.Height;
                }

                // Move the top-left corner for the next card.
                topLeft = topLeft.Offset(card.Width + VerticalMargin, 0);
            }
        }
    }
}
