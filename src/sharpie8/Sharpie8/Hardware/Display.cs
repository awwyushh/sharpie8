namespace Sharpie8;

public sealed class Display {
    public const int Width = 64;
    public const int Height = 32;

    public readonly bool[] _pixels = new bool[Height * Width];

    public void Clear() {
        Array.Clear(_pixels);
    }

    public bool GetPixel(int x, int y) {
        ValidateCoordinate(x, y);
        return _pixels[ToIndex(x, y)];
    }

    public ReadOnlySpan<bool> Pixels() {
        return _pixels;
    }

    public bool DrawSprite(int x, int y, ReadOnlySpan<byte> sprite) {
        bool collision = false;

        for (int row = 0; row < sprite.Length; row++)
        {
            byte spriteByte = sprite[row];
            for (int bit = 0; bit < 8; bit++)
            {
                if ((spriteByte & (0x80) >> bit) == 0) continue; // TODO: understand bit math here
                int px = Wrap(x + bit, Width);
                int py = Wrap(y + row, Height);

                int index = ToIndex(px, py);

		if(_pixels[index]) collision = true;

                _pixels[index] ^= true;
            }
        }
	
        return collision;
    }

    private static int ToIndex(int x, int y) {
        return y * Width + x;
    }

    private static int Wrap(int value, int max) {
        return value % max;
    }

    private static void ValidateCoordinate(int x, int y) {
	if(x<0 || x>=Width) throw new ArgumentOutOfRangeException(nameof(x));
	if(y<0 || y>=Height) throw new ArgumentOutOfRangeException(nameof(y));
    }
}
