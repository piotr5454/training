﻿using System.Collections.Generic;
using System.Linq;
using Toci.Hornets.GhostRider.TrainingFour.Generics;

namespace Toci.Hornets.Legnica.Patryk_Stulczewski.TrainingFour
{
    public class PatrykGenericList<T> : GhostRiderGenericList<T>
    {
        private int _top;
        private const int Capacity = 20;

        public PatrykGenericList()
        {
            _top = 0;
            items = new T[Capacity];
        }

        public override bool Add(T item)
        {
            if (_top == Capacity)
                return false;
           items[_top++] = item;
           return true;
        }

        public override bool Remove(T item)
        {
            var tab = items.Where(val => !val.Equals(item)).ToArray();            
            if (tab.Length != items.Length)
            {
                _top -= items.Length - tab.Length;
                items = tab;
                return true;
            }
            return false;

        }
    }
}