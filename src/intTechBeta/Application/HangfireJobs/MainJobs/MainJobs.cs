using System.Diagnostics;

public  class MainJobs
{
    public void FeedParser()
    {
        System.Console.WriteLine("sistem basarili");
        //py code
        string CurrentDirectory = Directory.GetCurrentDirectory();

        string OutDirectory = Path.Combine(CurrentDirectory, "..", "..", "..");

        string PythonDirectory = Path.Combine(OutDirectory, "feed_parser.py");

        string pythonInterpreterPath = "python";


        PythonDirectory = Path.GetFullPath(PythonDirectory);

        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = pythonInterpreterPath,
            Arguments = PythonDirectory,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = new Process { StartInfo = psi })
        {
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine("okuma islemi yapildi ");
        }
    }
    
}