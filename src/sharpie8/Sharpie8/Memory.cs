namespace Sharpie8;

public sealed class Memory {
    public const int size = 4096;

    private readonly byte[] _ram = new byte[size];

    public byte ReadByte(ushort address){
	ValidateAddress(address);
	return _ram[address];
    }

    public ushort ReadWord(ushort address){
	ValidateAddress((ushort)(address+1));
	return (ushort)((_ram[address] << 8) | (_ram[address+1]));
    }

    public void WriteByte(ushort address, byte val){
	ValidateAddress(address);
	_ram[address] = val;
    }

    private static void ValidateAddress(ushort address){
	if(address >= size){
	    throw new ArgumentOutOfRangeException(
		nameof(address),
		$"Memory address 0x{address:X3} out of range."
	    );
	}
    }
}
