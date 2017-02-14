// Decompiled with JetBrains decompiler
// Type: AsyncAwaitConsoleApplicationDecompiled.Program
// Assembly: AsyncAwaitConsoleApplicationDecompiled, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 98A33FA7-D4FC-4DCC-8189-EB70074401EA
// Assembly location: C:\Users\v-egkrus\Desktop\AsyncAwaitConsoleApplicationDecompiled.exe
// Compiler-generated code is shown

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncAwaitConsoleApplicationDecompiled
{
    internal class Program
    {
        public Program()
        {
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Program.startButton_Click();
            Console.ReadKey();
        }

        private static void startButton_Click()
        {
            Program.startButton_Clickd__1 stateMachine = new Program.startButton_Clickd__1();
            stateMachine.t__builder = AsyncVoidMethodBuilder.Create();
            stateMachine.__state = -1;
            stateMachine.t__builder.Start<Program.startButton_Clickd__1>(ref stateMachine);
        }

        private static Task<int> AccessTheWebAsync()
        {
            Program.AccessTheWebAsyncd__2 stateMachine = new Program.AccessTheWebAsyncd__2();
            stateMachine.t__builder = AsyncTaskMethodBuilder<int>.Create();
            stateMachine.__state = -1;
            stateMachine.t__builder.Start<Program.AccessTheWebAsyncd__2>(ref stateMachine);
            return stateMachine.t__builder.Task;
        }

        [CompilerGenerated]
        private sealed class startButton_Clickd__1 : IAsyncStateMachine
        {
            public int __state;
            public AsyncVoidMethodBuilder t__builder;
            private Task<int> getLengthTask5__1;
            private int contentLength5__2;
            private int s__3;
            private TaskAwaiter<int> u__1;

            public startButton_Clickd__1()
            {

            }

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.__state;
                try
                {
                    TaskAwaiter<int> awaiter;
                    if (num1 != 0)
                    {
                        Console.WriteLine("ONE:   Entering startButton_Click.\r\n           Calling AccessTheWebAsync.\r\n");
                        this.getLengthTask5__1 = Program.AccessTheWebAsync();
                        Console.WriteLine("\r\nFOUR:  Back in startButton_Click.\r\n           Task getLengthTask is started.\r\n           About to await getLengthTask -- no caller to return to.\r\n");
                        awaiter = this.getLengthTask5__1.GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.__state = 0;
                            this.u__1 = awaiter;
                            Program.startButton_Clickd__1 stateMachine = this;
                            this.t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, Program.startButton_Clickd__1>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.u__1;
                        this.u__1 = new TaskAwaiter<int>();
                        this.__state = -1;
                    }
                    int result = awaiter.GetResult();
                    new TaskAwaiter<int>();
                    this.s__3 = result;
                    this.contentLength5__2 = this.s__3;
                    Console.WriteLine("\r\nSIX:   Back in startButton_Click.\r\n           Task getLengthTask is finished.\r\n           Result from AccessTheWebAsync is stored in contentLength.\r\n           About to display contentLength and exit.\r\n");
                    Console.WriteLine("\r\nLength of the downloaded string: {0}.\r\n", (object)this.contentLength5__2);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    this.__state = -2;
                    this.t__builder.SetException(ex);
                    return;
                }
                this.__state = -2;
                this.t__builder.SetResult();
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        [CompilerGenerated]
        private sealed class AccessTheWebAsyncd__2 : IAsyncStateMachine
        {
            public int __state;
            public AsyncTaskMethodBuilder<int> t__builder;
            private HttpClient client5__1;
            private Task<string> getStringTask5__2;
            private string urlContents5__3;
            private string s__4;
            private TaskAwaiter<string> u__1;

            public AccessTheWebAsyncd__2()
            {

            }

            void IAsyncStateMachine.MoveNext()
            {
                int num1 = this.__state;
                int length;
                try
                {
                    TaskAwaiter<string> awaiter;
                    if (num1 != 0)
                    {
                        Console.WriteLine("\r\nTWO:   Entering AccessTheWebAsync.");
                        HttpClient httpClient = new HttpClient();
                        long num3 = 1000000;
                        httpClient.MaxResponseContentBufferSize = num3;
                        this.client5__1 = httpClient;
                        Console.WriteLine("\r\n           Calling HttpClient.GetStringAsync.\r\n");
                        this.getStringTask5__2 = this.client5__1.GetStringAsync("http://msdn.microsoft.com");
                        Console.WriteLine("\r\nTHREE: Back in AccessTheWebAsync.\r\n           Task getStringTask is started.");
                        Console.WriteLine("\r\n           About to await getStringTask and return a Task<int> to startButton_Click.\r\n");
                        awaiter = this.getStringTask5__2.GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.__state = 0;
                            this.u__1 = awaiter;
                            Program.AccessTheWebAsyncd__2 stateMachine = this;
                            this.t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, Program.AccessTheWebAsyncd__2>(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = this.u__1;
                        this.u__1 = new TaskAwaiter<string>();
                        this.__state = -1;
                    }
                    string result = awaiter.GetResult();
                    new TaskAwaiter<string>();
                    this.s__4 = result;
                    this.urlContents5__3 = this.s__4;
                    this.s__4 = (string)null;
                    Console.WriteLine("\r\nFIVE:  Back in AccessTheWebAsync.\r\n           Task getStringTask is complete.\r\n           Processing the return statement.\r\n           Exiting from AccessTheWebAsync.\r\n");
                    length = this.urlContents5__3.Length;
                }
                catch (Exception ex)
                {
                    this.__state = -2;
                    this.t__builder.SetException(ex);
                    return;
                }
                this.__state = -2;
                this.t__builder.SetResult(length);
            }

            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    }
}
