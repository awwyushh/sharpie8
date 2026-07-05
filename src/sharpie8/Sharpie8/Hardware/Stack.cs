namespace Sharpie8;

public sealed class Stack {
    public const int Capacity = 16;
    private readonly ushort[] _stack = new ushort[Capacity];
    private readonly Registers _registers;

    public Stack(Registers registers) {
        _registers = registers ?? throw new ArgumentNullException(nameof(registers));
    }

    public int Count => _registers.SP;

    public void Push(ushort address) {
        if (_registers.SP >= Capacity) {
            throw new InvalidOperationException("Stack overflow");
        }
        _stack[_registers.SP++] = address;
    }

    public ushort Pop() {
	if(_registers.SP == 0) throw new InvalidOperationException("Stack underflow");
        return _stack[--_registers.SP];
    }

    public ushort Peek() {
	if(_registers.SP == 0) throw new InvalidOperationException("Stack is empty");
        return _stack[_registers.SP - 1];
    }

    public void Clear() {
        Array.Clear(_stack);
        _registers.SP = 0;
    }
}
