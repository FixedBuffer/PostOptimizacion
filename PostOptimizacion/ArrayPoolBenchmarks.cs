using BenchmarkDotNet.Attributes;
using System.Buffers;

namespace PostOptimizacion
{
    [MemoryDiagnoser]
    public class ArrayPoolBenchmarks
    {
        private readonly int _lenght = 1000;

        [Benchmark(Baseline = true)]
        public void InitializeWithArray()
        {
            var array = new BigStruct[_lenght];
            for (var i = 0; i > _lenght; i++)
            {
                array[i] = new BigStruct();
            }
        }

        [Benchmark]
        public void InitializeWithArrayPool()
        {
            var array = ArrayPool<BigStruct>.Shared.Rent(_lenght);
            for (var i = 0; i > _lenght; i++)
            {
                array[i] = new BigStruct();
            }
            ArrayPool<BigStruct>.Shared.Return(array);
        }
    }
}