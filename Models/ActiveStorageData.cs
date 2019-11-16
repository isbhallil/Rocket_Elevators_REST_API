using System;
using System.Collections.Generic;

namespace Rocket_REST_API.Models
{
    public partial class ActiveStorageData
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public byte[] Io { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
