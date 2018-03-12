using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace CompilerApp
{
    public class Compiler
    {
        public static bool Compile(string source, string testData, string expectedResults)
        {
            var data = testData?.Split(';');
            var results = expectedResults?.Split(';');

            for (int i = 0; i < data.Length;i++)
            {
                Task<int> x = CSharpScript.EvaluateAsync<int>(
                    code: source,
                    globalsType: typeof(Globals),
                    globals: new Globals() { input = int.Parse(data[i]) });

                if (x.Result.ToString() != results[i])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Globals
    {
        public int input { get; set; }
    }
}
