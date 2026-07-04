using Xunit;

namespace Sharpie8.Tests;

public class MemoryTests {
    [Fact]
    public void Memory_IsZeroInitialized(){
	Memory memory = new();
	Assert.Equal(0, memory.ReadByte(123));
    }
}
