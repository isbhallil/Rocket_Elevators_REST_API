using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class ActiveStorageAttachments
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RecordType { get; set; }
        public long RecordId { get; set; }
        public long BlobId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ActiveStorageBlobs Blob { get; set; }
    }
}
