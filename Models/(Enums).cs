using System;

namespace AuslanAPI.Models
{
    public static class Enums
    {
        public enum RecordStatus
        {
            Unknown = 0,
            Active = 1,
            Deleted = 2,
            Completed = 4,
            InProgress = 8,
            Draft = 16
        }

        public enum SignCategory
        {
            Unknown = 0,
            Greetings = 1,
            Transport = 2,
            Colours = 4,
            Actions = 8
        }
    }
}

