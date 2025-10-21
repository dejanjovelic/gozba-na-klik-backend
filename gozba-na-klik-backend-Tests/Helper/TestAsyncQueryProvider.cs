using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace gozba_na_klik_backend_Tests.Helper
{
    public class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
            => new TestAsyncEnumerable<TEntity>(expression);

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
            => new TestAsyncEnumerable<TElement>(expression);

        public object Execute(Expression expression)
            => _inner.Execute(expression);

        public TResult Execute<TResult>(Expression expression)
            => _inner.Execute<TResult>(expression);


        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
            => new TestAsyncEnumerable<TResult>(expression);

        public ValueTask<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
            => new ValueTask<TResult>(_inner.Execute<TResult>(expression));
    }

}

