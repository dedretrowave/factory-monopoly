using UnityEngine;

namespace Src.DI
{
    public static class DependencyContext
    {
        public static DependencyCollection Dependencies { get; } = new();
    }
}