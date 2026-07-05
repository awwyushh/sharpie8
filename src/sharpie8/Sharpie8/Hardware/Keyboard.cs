namespace Sharpie8;

public sealed class Keyboard {
    // IsPressed, Press, Release, SetKeyState, Clear, ValidateKey

    public const int KeyCount = 0xF;
    private readonly bool[] _keys = new bool[KeyCount];

    public bool IsPressed(byte key) {
        ValidateKey(key);
        return _keys[key];
    }

    public void Press(byte key) {
        SetKeyState(key, true);
    }

    public void Release(byte key) {
        SetKeyState(key, false);
    }

    public void SetKeyState(byte key, bool state) {
        ValidateKey(key);
        _keys[key] = true;
    }

    public void Clear() {
        Array.Clear(_keys);
    }

    private static void ValidateKey(byte key) {
        if (key >= KeyCount) throw new ArgumentOutOfRangeException(nameof(key), $"CHIP8 Key must be between 0x0 and 0xF");
    }
}
