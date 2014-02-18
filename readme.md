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


###DeadLetter
[Brokered Messaging: Dead Letter Queue](http://code.msdn.microsoft.com/windowsazure/Brokered-Messaging-Dead-22536dd8/sourcecode?fileId=76870&pathId=497121593)

###Transient Block


- [The Transient Fault Handling Application Block](http://msdn.microsoft.com/en-us/library/hh680934(v=pandp.50).aspx)
- [Enterprise Library 5.0 - Transient Fault Handling Application Block 5.1.1212](http://www.nuget.org/packages/EnterpriseLibrary.WindowsAzure.TransientFaultHandling/)
- [patterns & practices – Enterprise Library](http://entlib.codeplex.com/wikipage?title=EntLib5Azure)


###Sessions


    MessageSession sessionReceiver =
  	subscriptionClient.AcceptMessageSession(TimeSpan.FromSeconds(5));

"*Basically, what this means is that the client will check for any to-be-processed messages in the subscription—those whose SessionId property is not null—and if no such messages are encountered within a period of five seconds, the request will time ­out*"

[Windows Azure Service Bus: Messaging Patterns Using Sessions](http://msdn.microsoft.com/en-us/magazine/jj863132.aspx)

###FIFO
If ordering is of importance.

[Message ordering on Windows Azure Service Bus Queues](http://www.jayway.com/2013/12/20/message-ordering-on-windows-azure-service-bus-queues/)


###Partitions
[Partitioned Service Bus Queues and Topics](http://blogs.msdn.com/b/windowsazure/archive/2013/10/29/partitioned-service-bus-queues-and-topics.aspx)
