using System;
using System.Threading;

namespace App.Scripts.Tools
{
    public class TokenDisposer : IDisposable
    {
        private readonly CancellationTokenSource _tokenSource;

        public TokenDisposer(CancellationTokenSource tokenSource)
        {
            _tokenSource = tokenSource;
        }

        public void Dispose()
        {
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }
    }
}