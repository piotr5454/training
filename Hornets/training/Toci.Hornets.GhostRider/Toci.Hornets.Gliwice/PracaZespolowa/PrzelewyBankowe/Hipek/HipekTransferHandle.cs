﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Hornets.GhostRider.Kir;

namespace Toci.Hornets.Gliwice.PracaZespolowa.PrzelewyBankowe.Hipek
{
    public class HipekTransferHandle : TransferHandle
    {
        public HipekTransferHandle()
        {
            this.BankName = "BZWBK";
        }

        protected override bool Send(BankTransfer transfer)
        {
            return IsMyDestination(transfer);
        }
    }
}
