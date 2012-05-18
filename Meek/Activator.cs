using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Meek
{
    public class Activator
    {
        private delegate object CreateTypeDelegate();
        private static Dictionary<Type, Delegate> _createTypeDelegateCache;

        private static Dictionary<Type, Delegate> CreateTypeDelegateCache
        {
            get
            {
                _createTypeDelegateCache = _createTypeDelegateCache ?? new Dictionary<Type, Delegate>();
                return _createTypeDelegateCache;
            }
        }

        public static object CreateInstance(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (!CreateTypeDelegateCache.ContainsKey(type))
            {
                var dm = new DynamicMethod("CreateInstance", type, Type.EmptyTypes, type);

                var il = dm.GetILGenerator();

                il.DeclareLocal(type);
                
                var constructor = type.GetConstructor(Type.EmptyTypes);
                
                if (Equals(constructor, null))
                    throw new Exception(string.Format("Unable to create instance of type {0}, unable to find a parameterless constructor of the type.", type.FullName));
                
                il.Emit(OpCodes.Newobj, constructor);    
                il.Emit(OpCodes.Stloc_0);
                il.Emit(OpCodes.Ldloc_0);
                il.Emit(OpCodes.Ret);

                var delgt = dm.CreateDelegate(typeof(CreateTypeDelegate));

                CreateTypeDelegateCache.Add(type, delgt);
            }
            var method = CreateTypeDelegateCache[type] as CreateTypeDelegate;

            if (Equals(method, null))
                throw new Exception(string.Format("Unable to create instance of type {0}", type.FullName));

            return method();
        }

        public static T CreateInstance<T>()
        {
            return (T)CreateInstance(typeof(T));
        }

       
    }
}
