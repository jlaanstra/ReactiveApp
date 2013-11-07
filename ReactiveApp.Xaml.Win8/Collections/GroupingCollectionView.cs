using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;

namespace ReactiveApp.Xaml.Collections
{
    public class GroupingCollectionView<T, U> : ICollectionView where T: IList<U>
    {
        public GroupingCollectionView(IList<T> coll)
        {
        }

        public Windows.Foundation.Collections.IObservableVector<object> CollectionGroups
        {
            get;
            private set;
        }

        public event EventHandler<object> CurrentChanged;

        public event CurrentChangingEventHandler CurrentChanging;

        public object CurrentItem
        {
            get { throw new NotImplementedException(); }
        }

        public int CurrentPosition
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasMoreItems
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCurrentAfterLast
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsCurrentBeforeFirst
        {
            get { throw new NotImplementedException(); }
        }

        public Windows.Foundation.IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentTo(object item)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToFirst()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToLast()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToNext()
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToPosition(int index)
        {
            throw new NotImplementedException();
        }

        public bool MoveCurrentToPrevious()
        {
            throw new NotImplementedException();
        }

        public event Windows.Foundation.Collections.VectorChangedEventHandler<object> VectorChanged;

        public int IndexOf(object item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public object this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(object item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(object item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        class ObservableVector : IObservableVector<object>
        {

            public ObservableVector(object list)
            {
            }

            public event VectorChangedEventHandler<object> VectorChanged;
            private void RaiseVectorChanged(CollectionChange collectionChange, int index)
            {
                var h = this.VectorChanged;
                if (h != null)
                {
                    h(this, new VectorChangedEventArgs { CollectionChange = collectionChange, Index = (uint)index });
                }
            }

            public int IndexOf(T item)
            {
                return this.inner.IndexOf(item);
            }

            public void Insert(int index, T item)
            {
                this.inner.Insert(index, item);
                this.RaiseVectorChanged(CollectionChange.ItemInserted, index);
            }

            public void RemoveAt(int index)
            {
                this.inner.RemoveAt(index);
                this.RaiseVectorChanged(CollectionChange.ItemRemoved, index);
            }

            public T this[int index]
            {
                get
                {
                    return this.inner[index];
                }
                set
                {
                    this.inner[index] = value;
                    this.RaiseVectorChanged(CollectionChange.ItemChanged, index);
                }
            }

            public void Add(T item)
            {
                this.inner.Add(item);
                this.RaiseVectorChanged(CollectionChange.ItemInserted, this.inner.Count - 1);
            }

            public void Clear()
            {
                this.inner.Clear();
                this.RaiseVectorChanged(CollectionChange.Reset, 0);
            }

            public bool Contains(T item)
            {
                return this.inner.Contains(item);
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                this.inner.CopyTo(array, arrayIndex);
            }

            public int Count
            {
                get { return this.inner.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool Remove(T item)
            {
                var index = this.inner.IndexOf(item);
                if (index == -1)
                {
                    return false;
                }
                this.RemoveAt(index);
                return true;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this.inner.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.inner.GetEnumerator();
            }

            class VectorChangedEventArgs : IVectorChangedEventArgs
            {
                public CollectionChange CollectionChange { get; set; }
                public uint Index { get; set; }
            }

        }

        class CollectionViewGroup : ICollectionViewGroup
        {
            public CollectionViewGroup()
            {
                this.GroupItems = new ObservableVector<object>();
            }

            public object Group
            {
                get { return this; }
            }

            public IObservableVector<object> GroupItems
            {
                get;
                set;
            }
        }
    }
}
