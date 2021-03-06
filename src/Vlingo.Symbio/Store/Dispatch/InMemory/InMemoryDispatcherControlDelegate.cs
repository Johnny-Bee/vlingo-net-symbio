// Copyright © 2012-2020 Vaughn Vernon. All rights reserved.
//
// This Source Code Form is subject to the terms of the
// Mozilla Public License, v. 2.0. If a copy of the MPL
// was not distributed with this file, You can obtain
// one at https://mozilla.org/MPL/2.0/.

using System.Collections.Generic;

namespace Vlingo.Symbio.Store.Dispatch.InMemory
{
    public class InMemoryDispatcherControlDelegate<TEntry, TState> : IDispatcherControlDelegate<TEntry, TState> where TEntry : IEntry where TState : class, IState
    {
        private readonly List<Dispatchable<TEntry, TState>> _dispatchables;

        public InMemoryDispatcherControlDelegate(List<Dispatchable<TEntry, TState>> dispatchables)
        {
            _dispatchables = dispatchables;
        }

        public IEnumerable<Dispatchable<TEntry, TState>> AllUnconfirmedDispatchableStates => _dispatchables;

        public void ConfirmDispatched(string dispatchId) => _dispatchables.RemoveAll(d => d.Id.Equals(dispatchId));

        public void Stop() => _dispatchables.Clear();
    }
}