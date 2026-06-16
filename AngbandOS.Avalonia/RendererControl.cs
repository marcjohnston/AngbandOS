using AngbandOS.Core.Interface;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using System;
using System.Runtime.InteropServices;

namespace AngbandOS.Avalonia
{
    // Single-control renderer (fast). It owns its buffers and draws in Render.
    internal class RendererControl : Control
    {
        private readonly object _sync = new();

        // Persistent back-buffer so updates are incremental (not a full redraw each Render).
        private WriteableBitmap _backBuffer;

        // Glyph alpha masks: one byte per pixel (0..255). Null entry means glyph not generated yet.
        private byte[][][] _glyphMasks;

        private const int cellHeight = 18;
        private const int cellWidth = 10;

        private PixelFormat PixelFmt => PixelFormat.Bgra8888;
        private AlphaFormat AlphaFmt => AlphaFormat.Premul;

        public RendererControl(int width, int height)
        {
            int w = width * cellWidth;
            int h = height * cellHeight;
            Width = w;
            Height = h;

            _backBuffer = new WriteableBitmap(new PixelSize(w, h), new Vector(96, 96), PixelFmt, AlphaFmt); // 96 DPI

            // initialize to background
            using var fb = _backBuffer.Lock();
//            ClearFramebuffer(fb.Address, fb.RowBytes, _backBuffer.PixelSize.Width, _backBuffer.PixelSize.Height, FromColorEnum(ColorEnum.Background));

            // Ensure glyph mask array exists
            _glyphMasks = new byte[256][][];

            // Use a temporary RenderTargetBitmap to render each glyph in opaque white on transparent background,
            // then copy alpha channel into mask array.
            var size = new PixelSize(cellWidth, cellHeight);
            var dpi = new Vector(96, 96);
            Typeface typeFace = new Typeface(new FontFamily("Courier New"));
            double fontSize = Math.Max(12.0, cellHeight - 2);

            for (int c = 0; c < 256; c++)
            {
                _glyphMasks[c] = new byte[32][];
                foreach (ColorEnum colorEnum in Enum.GetValues<ColorEnum>())
                {
                    var rt = new RenderTargetBitmap(size);
                    using (var ctx = rt.CreateDrawingContext())
                    {
                        // Disable text anti-aliasing explicitly
                        ctx.FillRectangle(Brushes.Transparent, new Rect(0, 0, cellWidth, cellHeight));

                        // draw glyph in solid white at baseline so it fits within cell.
                        Brush foreColorBrush = new SolidColorBrush(FromColorEnum(colorEnum));
                        var formatted = new FormattedText(((char)c).ToString(), System.Globalization.CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeFace, fontSize, foreColorBrush);

                        // center horizontally, place vertically so glyph baseline aligns visually
                        double textWidth = formatted.Width;
                        double x = Math.Max(0, (cellWidth - textWidth) / 2);
                        // place y at 0 so glyph is inside the cell; using formatted.Height to help vertical positioning
                        double y = Math.Max(0, (cellHeight - formatted.Height) / 2);

                        ctx.DrawText(formatted, new Point(x, y));
                    }

                    // copy pixels out of RenderTargetBitmap
                    int stride = cellWidth * 4;
                    byte[] pixels = new byte[cellHeight * stride];
                    GCHandle pinnedBuffer = GCHandle.Alloc(pixels, GCHandleType.Pinned);
                    try
                    {
                        IntPtr bufferPtr = pinnedBuffer.AddrOfPinnedObject();
                        rt.CopyPixels(new PixelRect(0, 0, cellWidth, cellHeight), bufferPtr, pixels.Length, stride);
                    }
                    finally
                    {
                        pinnedBuffer.Free();
                    }

                    _glyphMasks[c][(int)colorEnum] = pixels;
                }
            }
        }

        private Color FromColorEnum(ColorEnum color)
        {
            return color switch
            {
                ColorEnum.Background => Color.Parse("#000000"),
                ColorEnum.BrightWhite => Color.Parse("#FFFFFF"),
                ColorEnum.White => Color.Parse("#D3D3D3"),
                ColorEnum.Black => Color.Parse("#2F4F4F"),
                ColorEnum.Grey => Color.Parse("#696969"),
                ColorEnum.BrightGrey => Color.Parse("#A9A9A9"),
                ColorEnum.Silver => Color.Parse("#778899"),
                ColorEnum.Beige => Color.Parse("#FFE4B5"),
                ColorEnum.BrightBeige => Color.Parse("#F5F5DC"),
                ColorEnum.Red => Color.Parse("#8B0000"),
                ColorEnum.BrightRed => Color.Parse("#FF0000"),
                ColorEnum.Copper => Color.Parse("#D2691E"),
                ColorEnum.Orange => Color.Parse("#FF4500"),
                ColorEnum.BrightOrange => Color.Parse("#FFA500"),
                ColorEnum.Brown => Color.Parse("#8B4513"),
                ColorEnum.BrightBrown => Color.Parse("#DEB887"),
                ColorEnum.Gold => Color.Parse("#FFD700"),
                ColorEnum.Yellow => Color.Parse("#F0E68C"),
                ColorEnum.BrightYellow => Color.Parse("#FFFF00"),
                ColorEnum.Chartreuse => Color.Parse("#9ACD32"),
                ColorEnum.BrightChartreuse => Color.Parse("#7FFF00"),
                ColorEnum.Green => Color.Parse("#006400"),
                ColorEnum.BrightGreen => Color.Parse("#32CD32"),
                ColorEnum.Turquoise => Color.Parse("#00CED1"),
                ColorEnum.BrightTurquoise => Color.Parse("#00FFFF"),
                ColorEnum.Blue => Color.Parse("#0000CD"),
                ColorEnum.BrightBlue => Color.Parse("#00BFFF"),
                ColorEnum.Diamond => Color.Parse("#E0FFFF"),
                ColorEnum.Purple => Color.Parse("#800080"),
                ColorEnum.BrightPurple => Color.Parse("#EE82EE"),
                ColorEnum.Pink => Color.Parse("#FF1493"),
                ColorEnum.BrightPink => Color.Parse("#FF69B4"),
                _ => Colors.White
            };
        }

        // Clear back buffer to a color.
        public void Clear()
        {
            lock (_sync)
            {
                using (var fb = _backBuffer.Lock())
                {
                    int length = fb.RowBytes * fb.Size.Height;

                    byte[] clear = new byte[length];  // all zeros = transparent

                    Marshal.Copy(clear, 0, fb.Address, length);
                }
            }
            Dispatcher.UIThread.Post(InvalidateVisual);
        }

        // Update: draw only the incoming printLines into the persistent back buffer, then invalidate.
        // This writes background and glyph pixels directly into the WriteableBitmap memory using the glyph masks.
        public void Update(PrintLine[] printLines)
        {
            if (printLines == null || printLines.Length == 0) return;

            lock (_sync)
            {
                using var fb = _backBuffer.Lock();

                int fbWidth = _backBuffer.PixelSize.Width;
                int fbHeight = _backBuffer.PixelSize.Height;
                int rowBytes = fb.RowBytes;
                IntPtr baseAddr = fb.Address;

                foreach (var pl in printLines)
                {
                    // Clip out-of-range rows/cols quickly
                    if (pl.row < 0 || pl.col < 0) continue;

                    int destX = pl.col * cellWidth;
                    int destY = pl.row * cellHeight;
                    if (destX >= fbWidth || destY >= fbHeight) continue;

                    // compute drawing bounds
                    int drawW = Math.Min(cellWidth * pl.text.Length, fbWidth - destX);
                    int drawH = Math.Min(cellHeight, fbHeight - destY);

                    // fill background rectangle for the whole text span
                    Color backColor = FromColorEnum(pl.backColor);
                    FillRect(baseAddr, rowBytes, fbWidth, fbHeight, destX, destY, drawW, drawH, backColor);

                    // For each char, blit glyph pixels with foreColor directly from cached glyph bitmap
                    for (int i = 0; i < pl.text.Length; i++)
                    {
                        int ch = (byte)pl.text[i];
                        byte[] mask = _glyphMasks[ch][(int)pl.foreColor];

                        int glyphDestX = destX + i * cellWidth;
                        int glyphDestY = destY;

                        // clip per glyph if necessary
                        int gw = Math.Min(cellWidth, fbWidth - glyphDestX);
                        int gh = Math.Min(cellHeight, fbHeight - glyphDestY);
                        if (gw <= 0 || gh <= 0) continue;

                        for (int gy = 0; gy < gh; gy++)
                        {
                            IntPtr rowPtr = IntPtr.Add(baseAddr, (glyphDestY + gy) * rowBytes + glyphDestX * 4);

                            byte[] line = new byte[gw * 4];
                            Marshal.Copy(rowPtr, line, 0, gw * 4);

                            for (int gx = 0; gx < gw; gx++)
                            {
                                int pixOff = gx * 4;
                                int maskPixOff = (gy * cellWidth + gx) * 4;

                                byte srcB = mask[maskPixOff + 0];
                                byte srcG = mask[maskPixOff + 1];
                                byte srcR = mask[maskPixOff + 2];
                                byte srcA = mask[maskPixOff + 3];

                                if (srcA == 0)
                                    continue; // transparent pixel, keep destination

                                // Overwrite destination pixel with glyph pixel (premultiplied BGRA)
                                line[pixOff + 0] = srcB;
                                line[pixOff + 1] = srcG;
                                line[pixOff + 2] = srcR;
                                line[pixOff + 3] = srcA;
                            }

                            Marshal.Copy(line, 0, rowPtr, gw * 4);
                        }
                    }
                }
            }

            Dispatcher.UIThread.Post(InvalidateVisual);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            // Desired size is the pixel size of the backbuffer, converted to device-independent units (DIPs)
            // Avalonia units are DIPs, so convert pixels using 96 DPI (1 DIP = 1 pixel at 96 DPI)
            double desiredWidth = _backBuffer.PixelSize.Width * 1.0;
            double desiredHeight = _backBuffer.PixelSize.Height * 1.0;

            return new Size(desiredWidth, desiredHeight);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // Arrange to exactly the size of the backbuffer in pixels (DIPs)
            double width = _backBuffer.PixelSize.Width * 1.0;
            double height = _backBuffer.PixelSize.Height * 1.0;

            return new Size(width, height);
        }

        // Helper: fill an axis-aligned rectangle in premultiplied BGRA
        private static void FillRect(IntPtr baseAddr, int rowBytes, int fbWidth, int fbHeight, int x, int y, int w, int h, Color color)
        {
            if (w <= 0 || h <= 0) return;

            byte a = color.A;
            byte r = color.R;
            byte g = color.G;
            byte b = color.B;
            float alpha = a / 255f;
            byte pr = (byte)(r * alpha);
            byte pg = (byte)(g * alpha);
            byte pb = (byte)(b * alpha);

            int rowLen = w * 4;
            byte[] row = new byte[rowLen];
            for (int i = 0; i < w; i++)
            {
                int off = i * 4;
                row[off + 0] = pb;
                row[off + 1] = pg;
                row[off + 2] = pr;
                row[off + 3] = a;
            }

            for (int yy = 0; yy < h; yy++)
            {
                IntPtr dest = IntPtr.Add(baseAddr, (y + yy) * rowBytes + x * 4);
                Marshal.Copy(row, 0, dest, rowLen);
            }
        }

        public override void Render(DrawingContext context)
        {
            lock (_sync)
            {
                var srcRect = new Rect(0, 0, _backBuffer.PixelSize.Width, _backBuffer.PixelSize.Height);
                var dstRect = new Rect(0, 0, _backBuffer.PixelSize.Width, _backBuffer.PixelSize.Height);
                context.DrawImage(_backBuffer, srcRect, dstRect);
            }
        }
    }
}