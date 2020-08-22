using System;
using System.Collections.Generic;

namespace ReadingDB
{
    public partial class Reading
    {
        public int ReadingId { get; set; }
        public string ReadingTitle { get; set; }
        public string ReadingAuthor { get; set; }
        public string ReadingType { get; set; }
        public int ReadingPage { get; set; }
        public string ReadingNotes { get; set; }
        public DateTime ReadingModifiedDate { get; set; }
    }
}
