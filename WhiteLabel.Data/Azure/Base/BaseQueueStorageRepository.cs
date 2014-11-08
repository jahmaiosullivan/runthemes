using Microsoft.WindowsAzure.Storage.Queue;

namespace WhiteLabel.Data.Azure.Base
{
    public abstract class BaseQueueStorageRepository
    {
        protected readonly ICloudClientWrapper cloudClientWrapper;

        protected BaseQueueStorageRepository(ICloudClientWrapper cloudClientWrapper)
        {
            this.cloudClientWrapper = cloudClientWrapper;
        }

        public void Delete(string queueName)
        {
            var queue = cloudClientWrapper.QueueClient.GetQueueReference(queueName);
            queue.DeleteIfExists();
        }

        public CloudQueue GetOrCreate(string queueName)
        {
            var queue = cloudClientWrapper.QueueClient.GetQueueReference(queueName);
            queue.CreateIfNotExists();
            return queue;
        }

    }
}
