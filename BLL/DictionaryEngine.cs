using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVaultApp.BLL
{
    public class DictionaryEngine
    {
        public delegate void ProgressHandler(string currentAttempt, long totalAttempts, TimeSpan elapsed);
        public event ProgressHandler OnProgress;

        private readonly List<string> _commonPasswords = new List<string>
        {
            "password", "123456", "admin", "welcome", "qwerty", "password123", 
            "login", "secure", "vault", "secret", "p@ssword", "root", "user"
        };

        public async Task RunSimulation(string target, CancellationToken token)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long counter = 0;

            await Task.Run(() =>
            {
                foreach (string word in _commonPasswords)
                {
                    if (token.IsCancellationRequested) break;

                    counter++;
                    OnProgress?.Invoke(word, counter, sw.Elapsed);

                    if (word.Equals(target, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    // Delay to simulate processing and make it visible
                    Thread.Sleep(200);
                }
            }, token);
        }

        public async Task RunHybridSimulation(string target, CancellationToken token)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long counter = 0;

            await Task.Run(() =>
            {
                foreach (string word in _commonPasswords)
                {
                    if (token.IsCancellationRequested) break;

                    // Hybrid: Try word + simple suffix
                    string[] suffixes = { "1", "123", "!", "2024" };
                    foreach (var suffix in suffixes)
                    {
                        if (token.IsCancellationRequested) break;

                        counter++;
                        string guess = word + suffix;
                        OnProgress?.Invoke(guess, counter, sw.Elapsed);

                        if (guess.Equals(target, StringComparison.OrdinalIgnoreCase)) return;

                        Thread.Sleep(100);
                    }
                }
            }, token);
        }
    }
}
