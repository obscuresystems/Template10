﻿using System;
using Windows.Foundation;
using Windows.UI.Core;

namespace Prism.Services
{
    public interface IGestureService
    {
        event EventHandler BackRequested;
        event EventHandler ForwardRequested;
        event TypedEventHandler<object, KeyDownEventArgs> KeyDown;
        event EventHandler MenuRequested;
        event EventHandler RefreshRequested;
        event EventHandler SearchRequested;

        void RaiseRefreshBackRequested();
        void RaiseBackRequested();
        void RaiseForwardRequested();
        void RaiseSearchRequested();
        void RaiseMenuRequested();
    }
}