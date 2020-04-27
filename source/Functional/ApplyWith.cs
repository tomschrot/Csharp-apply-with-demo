
using System;
using System.Runtime.CompilerServices;

namespace Functional {

    // FIXME: Inling of methods may increase performance!
    // FIXME: Uncomment the compiler option ahead each method.

    public static partial class Extensions {

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T with<T>(T entity, Action<T> action) =>
                entity.apply(action); 

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T apply<T>(this T entity, Action<T> action) {
                action(entity);
                return entity;
        }
    }
}