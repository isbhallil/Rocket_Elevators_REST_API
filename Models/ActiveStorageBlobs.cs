using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class ActiveStorageBlobs
    {
        public ActiveStorageBlobs()
        {
            ActiveStorageAttachments = new HashSet<ActiveStorageAttachments>();
        }

        public long Id { get; set; }
        public string Key { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public string Metadata { get; set; }
        public long ByteSize { get; set; }
        public string Checksum { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<ActiveStorageAttachments> ActiveStorageAttachments { get; set; }
    }
}
