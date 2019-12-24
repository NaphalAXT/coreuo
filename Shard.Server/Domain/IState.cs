﻿namespace Shard.Server.Domain
{
    public interface IState<TMobile>
        where TMobile : IMobile
    {
        TMobile Mobile { get; set; }

        public byte MobileQueryType { get; set; }

        public int MobileQuerySerial { get; set; }
    }
}