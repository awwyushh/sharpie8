namespace Sharpie8.Rom;

public static class RomLoader {
    public static byte[] Load(string path) {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

	if(!File.Exists(path)) throw new FileNotFoundException(nameof(path), $"ROM not found: {path}");

        byte[] rom = File.ReadAllBytes(path);
	if(rom.Length == 0) throw new InvalidDataException("ROM file is empty");
        return rom;
    }
}
