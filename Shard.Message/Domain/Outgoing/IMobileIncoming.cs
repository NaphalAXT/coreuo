﻿using System.Collections.Generic;
using System.Linq;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IMobileIncoming<TMobileEquip> :
        ISerial,
        IBody,
        ILocation,
        IDirection,
        IHue,
        IStatusFlags,
        INotoriety
        where TMobileEquip : IMobileEquip
    {
        public List<TMobileEquip> Equipment { get; set; }

        internal void WriteMobileIncoming(IData data)
        {
            data.Write(3, Serial);

            data.Write(7, Body);

            data.Write(9, LocationX);

            data.Write(11, LocationY);

            data.Write(13, LocationZ);

            data.Write(14, Direction);

            data.Write(15, Hue);

            data.Write(17, StatusFlags);

            data.Write(18, Notoriety);

            foreach (var (equip, index) in Equipment.Select((e,i) => (e,i))) equip.WriteMobileEquipment(EquipmentSize(index), data);

            data.Write(19 + EquipmentSize() , 0);
        }

        internal int EquipmentSize(int? index = null)
        {
            var filtered = index == null ? Equipment : Equipment.Take(index.Value);

            return filtered.Sum(e => e.HasHue() ? 9 : 7);
        }
    }
}
