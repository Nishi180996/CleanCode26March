using System;

public class PrinterDriver
{
    private Printer printer;
    private IInputDevice inputDevice;

	public PrinterDriver(Printer printer , IInputDevice inputDevice)
	{
		this.printer = printer;
        this.inputDevice = inputDevice;
	}

    public void Print()
    {
        while (!inputDevice.isEndOFFile)
        {
            buffer page = inputDevice.getNextPage();
            this.printer(page);
        }
    }
}
