using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LinkedList.Models
{
    /// <summary>
    /// Односвязный список
    /// </summary>

    public class LinkedList<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>

        public Item<T> Head { get; private set; }

        /// <summary>
        /// Последний элемент списка
        /// </summary>
  
        public Item<T> Tail { get; private set; }

        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Создать пустой список
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>

        public LinkedList(T data)
        {
            SetHeadAndTail(data);
        }

        /// <summary>
        /// Добавить данные в конец списка
        /// </summary>

        public void Add(T data)
        {           
            if (Tail != null)
            {
                Item<T> item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>

        public void Delete(T data)
        {
            if (Head.Data.Equals(data))
            {
                Head.Next = Head;
                Count--;
                return;
            }
            var current = Head.Next;
            var previous = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    Count--;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }
        private void SetHeadAndTail(T data)
        {
            Item<T> item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var current = Head;
            while (current != null) 
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public override string ToString()
        {
            return "Linked List" + Count + " элементов";
        }
    }
}
