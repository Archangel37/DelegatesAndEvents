using System;
using System.Collections;
using System.Collections.Generic;

namespace DelegatesAndEvents
{
    class TrackableList<T> : IList<T>
    {
        /// <summary>
        ///     Публичный эвент-хэндлер для события изменения
        /// </summary>
        public event EventHandler<TrackableListEventArgs<T>> ChangeEvent = delegate { };

        public IList<T> _list = new List<T>();


        //сначала не обявлял тут, а к каждому методу был конкретный var args = new.. 
        //почему индекс -1 - просто подумал, что в 0 лучше не залезать с дефолтными значениями, хотя отрабатывает и с 0
        public TrackableListEventArgs<T> Args = new TrackableListEventArgs<T>(-1, default(T), default(T), 0); //Nothing

        /// <summary>
        ///     Добавление значения в лист
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            _list.Add(value);
            var index = _list.Count - 1;
            var oldValue = default(T);
            Args = new TrackableListEventArgs<T>(index, oldValue, value, 1);
            OnChangeEvent(Args);
        }

        /// <summary>
        ///     Очистка всего листа
        /// </summary>
        public void Clear()
        {
            for (var i = 0; i < _list.Count; i++)
            {
                var oldValue = _list[i];
                var index = i;
                _list[i] = default(T);
                Args = new TrackableListEventArgs<T>(index, oldValue, default(T), 2);
                OnChangeEvent(Args);
            }
        }

        /// <summary>
        ///     Содержит ли лист элемент item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        /// <summary>
        ///     Копирует элементы коллекции в массив Array, начиная с индекса arrayIndex
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Удаление элемента из листа
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool ICollection<T>.Remove(T item)
        {
            return _list.Remove(item);
        }

        /// <summary>
        ///     Подсчёт количества элементов в листе
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        ///     Есть ли свойство у листа "только для чтения"
        /// </summary>
        public bool IsReadOnly => _list.IsReadOnly;

        /// <summary>
        ///     Получение индекса элемента item в листе
        /// </summary>
        /// <param name="item">элемент, который ищем</param>
        /// <returns></returns>
        public int IndexOf(T item) => _list.IndexOf(item);

        /// <summary>
        ///     Возвращает перечислитель листа
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        ///     Вставка значения в лист по индексу
        /// </summary>
        /// <param name="index">индекс, куда вставить</param>
        /// <param name="value">значение, которое надо вставить</param>
        public void Insert(int index, T value)
        {
            //var oldValue = _list[index];
            _list.Insert(index, value);

            Args = new TrackableListEventArgs<T>(index, default(T), value, 3);
            OnChangeEvent(Args);
        }

        /// <summary>
        ///     Удаление элемента по индексу
        /// </summary>
        /// <param name="index">индекс</param>
        public void RemoveAt(int index)
        {
            var oldValue = _list[index];
            _list.RemoveAt(index);
            Args = new TrackableListEventArgs<T>(index, oldValue, default(T), 4);
            OnChangeEvent(Args);
        }

        /// <summary>
        ///     Получение или установка элемента через индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get => _list[index];
            set
            {
                var oldValue = _list[index];
                Args = new TrackableListEventArgs<T>(index, oldValue, value, 5);
                OnChangeEvent(Args);
                _list[index] = value;
            }
        }

        /// <summary>
        ///     Удаление элемента по значению
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            var index = _list.IndexOf(value);
            var oldValue = _list[IndexOf(value)];
            _list.Remove(value);
            var newValue = default(T);
            if (index <= _list.Count - 1)
                newValue = _list[index];
            Args = new TrackableListEventArgs<T>(index, oldValue, newValue, 6);
            OnChangeEvent(Args);
        }

        /// <summary>
        ///     Событие при изменении листа
        /// </summary>
        /// <param name="args"></param>
        protected virtual void OnChangeEvent(TrackableListEventArgs<T> args)
        {
            ChangeEvent?.Invoke(this, args);
        }
    }
}
