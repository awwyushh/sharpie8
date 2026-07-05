using Xunit;

namespace Sharpie8.Tests;

public class MemoryTests
{
    [Fact]
    public void Memory_IsZeroInitialized()
    {
        var memory = new Memory();
        Assert.Equal(0, memory.ReadByte(0));
        Assert.Equal(0, memory.ReadByte(4095));
    }

    [Fact]
    public void WriteByte_StoresValue()
    {
        var memory = new Memory();
        memory.WriteByte(0x123, 0xAB);
        Assert.Equal(0xAB, memory.ReadByte(0x123));
    }
}
