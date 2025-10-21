using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gozba_na_klik_backend_Tests.Helper
{
    public class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;
        public TestAsyncEnumerator(IEnumerator<T> inner) => _inner = inner;
        public T Current => _inner.Current;
        public ValueTask DisposeAsync() { _inner.Dispose(); return default; }
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(_inner.MoveNext());
    }
}
