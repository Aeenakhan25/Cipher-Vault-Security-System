using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVaultApp.BLL
{
    public class BruteForceEngine
    {
        public delegate void ProgressHandler(string currentAttempt, long totalAttempts, TimeSpan elapsed);
        public event ProgressHandler OnProgress;

        public async Task RunSimulation(string target, CancellationToken token)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long counter = 0;
            char[] chars = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();

            await Task.Run(() =>
            {
                // Note: This is a simplified "visual" simulation to avoid actual exponential complexity 
                // while demonstrating the concept.
                while (!token.IsCancellationRequested)
                {
                    counter++;
                    
                    // Simulate generating a guess (simplified for demonstration)
                    string guess = GenerateMockGuess(counter, chars);

                    if (counter % 5000 == 0) // Update UI periodically
                    {
                        OnProgress?.Invoke(guess, counter, sw.Elapsed);
                        // Slow down slightly to make it visible
                        Thread.Sleep(1);
                    }

                    if (guess == target) break;

                    // In a real simulation, we might limit the time to prevent freezing
                    if (sw.Elapsed.TotalMinutes > 2) break;
                }
            }, token);
        }

        private string GenerateMockGuess(long index, char[] charset)
        {
            // Simple mapping to charset for demonstration
            string result = "";
            long temp = index;
            while (temp > 0 && result.Length < 8)
            {
                result += charset[temp % charset.Length];
                temp /= charset.Length;
            }
            return result;
        }
    }
}
