﻿namespace Shard.Message.Domain.Incoming
{
    public interface IChatRequest
    {
        public string ChatName { set; }

        internal int ReadChatRequest(IData data)
        {
            ChatName = data.ReadAscii(1, 63);

            return 64;
        }
    }
}
