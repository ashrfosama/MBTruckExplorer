using Microsoft.VisualC;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size=1), DebugInfoInPDB, MiscellaneousBits(0x40), NativeCppClass]
internal struct _DebugMallocator<int>
{
    public static unsafe void <MarshalCopy>(_DebugMallocator<int>*, _DebugMallocator<int>*)
    {
    }

    public static unsafe void <MarshalDestroy>(_DebugMallocator<int>*)
    {
    }
    [StructLayout(LayoutKind.Sequential, Size=1), CLSCompliant(false), NativeCppClass, MiscellaneousBits(0x41), DebugInfoInPDB]
    public struct rebind<std::tr1::_Ref_count_del_alloc<__ExceptionPtr,void (__clrcall*)(__ExceptionPtr *),_DebugMallocator<int> > >
    {
    }
}

