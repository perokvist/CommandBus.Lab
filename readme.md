#CommandBus.Lab

Simple Starter-Kit for an Azure Command Bus Lab.

##Get started
1. Install Azure SDK > 2.2
2. Create a Service Bus instance, and update the app.config files with the connection.
3. Create Topic "commands" and subscription "nodeOneSub" through namespace manager or portal.


###Retry

*"The Client-side Retry Policy feature enables you to set a retry policy on transient message delivery errors."*


    MessagingFactory factory = MessagingFactory.Create();
	factory.RetryPolicy = RetryExponential.Default; // retry on transient errors until the OperationTimeout is reached
	factory.RetryPolicy = RetryPolicy.NoRetry; // disables retry for tranisent errors

Source:
[Whats new i Azure SDK 2.1](http://msdn.microsoft.com/en-us/library/windowsazure/dn275924.aspx)

#####2.2

    var messagingFactory = MessagingFactory.Create();
	 _client = messagingFactory.CreateSubscriptionClient(topic, subscription);
    _client.RetryPolicy = new RetryExponential(...);

###Sessions


    MessageSession sessionReceiver =
  	subscriptionClient.AcceptMessageSession(TimeSpan.FromSeconds(5));

"*Basically, what this means is that the client will check for any to-be-processed messages in the subscription—those whose SessionId property is not null—and if no such messages are encountered within a period of five seconds, the request will time ­out*"

[Windows Azure Service Bus: Messaging Patterns Using Sessions](http://msdn.microsoft.com/en-us/magazine/jj863132.aspx)

###FIFO
Ordering of commands could be important.

[Message ordering on Windows Azure Service Bus Queues](http://www.jayway.com/2013/12/20/message-ordering-on-windows-azure-service-bus-queues/)