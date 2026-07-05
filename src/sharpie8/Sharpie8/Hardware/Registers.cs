namespace Sharpie8;

public sealed class Registers {
    public const int Count = 16;
    public const int FlagRegister = 0xF;
    public const ushort ProgramStart = 0x200;

    private readonly byte[] _v = new byte[Count];

    public ushort I { get; set; }
    public ushort PC { get; private set; }
    public byte SP { get; set; }

    public Registers() {
        Reset();
    }

    public byte this[int index]{
        get
        {
            ValidateIndex(index);
            return _v[index];
        }
        set {
            ValidateIndex(index);
            _v[index] = value;
        }
    }

    public void AdvancePC() {
        PC += 2;
    }

    public void Jump(ushort address) {
        PC = address;
    }

    public void Reset() {
        Array.Clear(_v);
        I = 0;
        SP = 0;
        PC = ProgramStart;
    }

    public static void ValidateIndex(int index){
        if (index < 0 || index >= Count) {
            throw new ArgumentOutOfRangeException(
            nameof(index),
            $"Register index must be between 0 and {Count - 1}"
            );
        }
    }
}
