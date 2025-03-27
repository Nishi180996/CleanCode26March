using System;

public interface IInputDevice
{
    public bool isEndOFFile();
    public buffer getNextPage();
}
