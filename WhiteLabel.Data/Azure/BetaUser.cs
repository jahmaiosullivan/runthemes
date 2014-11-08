using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace WhiteLabel.Data.Azure
{
    public class BetaUser : TableEntity
    {
        public BetaUser()
        {
            PartitionKey = "BetaUser_" + DateTime.UtcNow.ToString("MMddyyyy");
        }

        public string Email { get; set; }

        public DateTime CreatedDate
        {
            get { return DateTime.UtcNow; }
        }
    }
}