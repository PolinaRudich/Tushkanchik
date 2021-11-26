﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tushkanchik
{
    public class Card : CashAccount
    {
        public bool cashBack { get; set; }
        public float percentOfCashBack { get; set; }

        public Card( bool CashBack , float PetcentOfCashBack, List<User> Holder, decimal Balance, string Name)
            :base (Holder, Balance, Name)
        {
            cashBack = CashBack;
            percentOfCashBack = PetcentOfCashBack;
        }
     }
}
