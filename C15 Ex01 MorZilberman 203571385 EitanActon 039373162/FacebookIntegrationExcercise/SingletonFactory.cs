using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FacebookIntegrationExcercise
{
    public static class SingletonFactory
    {
        private static readonly object sr_SingletonCreationLock = new object();
        private static Dictionary<Type, object> s_SingletonForType = new Dictionary<Type, object>();
        private const bool v_NonPublic = true;

        public static object GetSingleton<T>(T i_SingletonType) where T : Type
        {
            if (!s_SingletonForType.ContainsKey(i_SingletonType))
            {
                lock (sr_SingletonCreationLock)
                {
                    if (!s_SingletonForType.ContainsKey(i_SingletonType))
                    {
                        s_SingletonForType.Add(i_SingletonType, Activator.CreateInstance(i_SingletonType, v_NonPublic));
                    }
                }
            }

            return s_SingletonForType[i_SingletonType];
        }
    }
}
