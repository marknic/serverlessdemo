using System;

public static void Run(string queueItem, ICollector<QueuedMessage> tableItem, TraceWriter log)
{
    log.Info($"Queue trigger function processed with this incoming message: {queueItem}");

    tableItem.Add(new QueuedMessage()
    {
        PartitionKey = "Messages",
        RowKey = Guid.NewGuid().ToString(),
        Message = queueItem
    });

}

public class QueuedMessage
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Message { get; set; }
}