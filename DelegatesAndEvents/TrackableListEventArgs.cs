using System;


namespace DelegatesAndEvents
{
    class TrackableListEventArgs<T> : EventArgs
    {
        /// <summary>
        ///     Перечислитель событий для коллекции
        /// </summary>
        private enum EvtHappened : byte
        {
            Nothing,
            Add,
            Clear,
            Insert,
            RemoveAt,
            NewValue,
            Remove
        };

        /// <summary>
        ///     Индекс значения листа
        /// </summary>
        public readonly int Index;

        /// <summary>
        ///     Новое значение по этому индексу
        /// </summary>
        public readonly T NewValue;

        /// <summary>
        ///     Старое значение по индексу
        /// </summary>
        public readonly T OldValue;

        /// <summary>
        ///     Что произошло по индексу
        /// </summary>
        public readonly string WhatHappened;

        /// <summary>
        ///     Собственно, сама сущность класса TrackableListEventArgs
        /// </summary>
        /// <param name="index">индекс</param>
        /// <param name="oldValue">старое значение</param>
        /// <param name="newValue">новое значение</param>
        /// <param name="whatHappened">что произошло по этому индексу</param>
        public TrackableListEventArgs(int index, T oldValue, T newValue, byte whatHappened)
        {
            Index = index;
            OldValue = oldValue;
            NewValue = newValue;
            //тут преобразование из byte в значения string:
            WhatHappened = Enum.GetName(typeof(EvtHappened), whatHappened);
        }
    }
}
