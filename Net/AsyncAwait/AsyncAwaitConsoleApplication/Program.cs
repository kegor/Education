using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwaitConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            startButton_Click();
            Console.ReadKey();
        }

        static async void startButton_Click()
        {
            // The display lines in the example lead you through the control shifts.
            Console.WriteLine("ONE:   Entering startButton_Click.\r\n" +
                "           Calling AccessTheWebAsync.\r\n");

            Task<int> getLengthTask = AccessTheWebAsync();

            Console.WriteLine("\r\nFOUR:  Back in startButton_Click.\r\n" +
                "           Task getLengthTask is started.\r\n" +
                "           About to await getLengthTask -- no caller to return to.\r\n");

            int contentLength = await getLengthTask;

            Console.WriteLine("\r\nSIX:   Back in startButton_Click.\r\n" +
                "           Task getLengthTask is finished.\r\n" +
                "           Result from AccessTheWebAsync is stored in contentLength.\r\n" +
                "           About to display contentLength and exit.\r\n");

            Console.WriteLine("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
            Console.ReadKey();
        }

        static async Task<int> AccessTheWebAsync()
        {
            Console.WriteLine("\r\nTWO:   Entering AccessTheWebAsync.");

            // Declare an HttpClient object and increase the buffer size. The default
            // buffer size is 65,536.
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            Console.WriteLine("\r\n           Calling HttpClient.GetStringAsync.\r\n");

            // GetStringAsync returns a Task<string>. 
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            Console.WriteLine("\r\nTHREE: Back in AccessTheWebAsync.\r\n" +
                "           Task getStringTask is started.");

            // AccessTheWebAsync can continue to work until getStringTask is awaited.

            Console.WriteLine("\r\n           About to await getStringTask and return a Task<int> to startButton_Click.\r\n");

            // Retrieve the website contents when task is complete.
            string urlContents = await getStringTask;

            Console.WriteLine("\r\nFIVE:  Back in AccessTheWebAsync." +
                "\r\n           Task getStringTask is complete." +
                "\r\n           Processing the return statement." +
                "\r\n           Exiting from AccessTheWebAsync.\r\n");

            return urlContents.Length;
        }
    }
}
