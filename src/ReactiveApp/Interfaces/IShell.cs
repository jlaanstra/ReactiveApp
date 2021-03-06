﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveApp.Interfaces;
using ReactiveUI;

namespace ReactiveApp.Interfaces
{
    public interface IShell
    {
        IObservable<bool> ViewAsync(IJournalEntry entry, NavigationMode mode);

        IObservable<bool> ViewAsync<V>(V view, NavigationMode mode, object parameter = null) where V : IView;

        IObservable<bool> IsNavigationActive { get; }

        IReactiveList<IJournalEntry> BackStack { get; }

        IReactiveList<IJournalEntry> ForwardStack { get; }

        IObservable<NavigatingInfo> Navigating { get; }

        IObservable<NavigatedInfo> Navigated { get; }

        IObservable<IJournalEntry> CurrentJournalEntry { get; }

        /// <summary>
        /// Gets the stream of views. Subscribing to this observable should always return a value immediately.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        IObservable<IView> CurrentView { get; }

        /// <summary>
        /// Makes the shell visible on screen.
        /// </summary>
        /// <returns></returns>
        IObservable<Unit> Activate();

        /// <summary>
        /// Observable that indicates whether the Shell is visible on screen.
        /// </summary>
        /// <value>
        /// The activated.
        /// </value>
        IObservable<Unit> Activated { get; }

        /// <summary>
        /// Gets or sets a value indicating whether a view journal on the back- and forwardstack is recorded or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the journal is disabled; otherwise, <c>false</c>.
        /// </value>
        bool DisableJournal { get; set; }

        /// <summary>
        /// Adds the overlay to the Shell.
        /// </summary>
        /// <param name="overlay">The overlay.</param>
        /// <returns></returns>
        IDisposable AddOverlay(object overlay);
    }    
}
