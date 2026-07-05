namespace Sharpie8;

public sealed class Timers {
    public byte Delay { get; set; }
    public byte Sound { get; set; }
    public bool IsSoundActive => Sound > 0;

    public void Tick() {
	if(Delay > 0) Delay--;
	if(Sound > 0) Sound--;
    }

    public void Reset() {
        Delay = 0;
        Sound = 0;
    }
}
