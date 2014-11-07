﻿using ENode.Infrastructure;
using EQueue.Clients.Consumers;
using EQueue.Protocols;

namespace ENode.EQueue
{
    public abstract class MessageProcessContext<TMessage> : IMessageProcessContext<TMessage> where TMessage : class
    {
        protected readonly QueueMessage _queueMessage;
        protected readonly IMessageContext _messageContext;
        protected readonly TMessage _message;

        public MessageProcessContext(QueueMessage queueMessage, IMessageContext messageContext, TMessage message)
        {
            _queueMessage = queueMessage;
            _messageContext = messageContext;
            _message = message;
        }

        public virtual void OnMessageProcessed(TMessage message)
        {
            _messageContext.OnMessageHandled(_queueMessage);
        }
    }
}
