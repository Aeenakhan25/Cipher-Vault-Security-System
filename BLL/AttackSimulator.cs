using System;
using System.Threading;
using System.Threading.Tasks;

namespace SecureVaultApp.BLL
{
    public enum AttackType
    {
        BruteForce,
        Dictionary,
        Hybrid
    }

    /// <summary>
    /// Coordinator for various attack simulations. 
    /// Implements requirements for Module 5.
    /// </summary>
    public class AttackSimulator
    {
        private readonly BruteForceEngine _bruteEngine = new BruteForceEngine();
        private readonly DictionaryEngine _dictEngine = new DictionaryEngine();

        public delegate void ProgressUpdate(string attempt, long count, TimeSpan elapsed);
        public event ProgressUpdate OnSimulationUpdate;

        public AttackSimulator()
        {
            _bruteEngine.OnProgress += (a, c, e) => OnSimulationUpdate?.Invoke(a, c, e);
            _dictEngine.OnProgress += (a, c, e) => OnSimulationUpdate?.Invoke(a, c, e);
        }

        public async Task StartAttack(AttackType type, string target, CancellationToken token)
        {
            SecurityLogger.Log("Attack Simulation", $"Started {type} simulation against target: {target}");
            switch (type)
            {
                case AttackType.BruteForce:
                    await _bruteEngine.RunSimulation(target, token);
                    break;
                case AttackType.Dictionary:
                    await _dictEngine.RunSimulation(target, token);
                    break;
                case AttackType.Hybrid:
                    await _dictEngine.RunHybridSimulation(target, token);
                    break;
            }
        }
    }
}
